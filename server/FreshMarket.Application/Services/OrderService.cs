using FreshMarket.Application.DTOs.Orders;
using FreshMarket.Application.Interfaces;
using FreshMarket.Domain.Entities;

namespace FreshMarket.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICartRepository _cartRepository;
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IProductRepository _productRepository;

    public OrderService(
        IOrderRepository orderRepository,
        ICartRepository cartRepository,
        IInventoryRepository inventoryRepository,
        IProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _cartRepository = cartRepository;
        _inventoryRepository = inventoryRepository;
        _productRepository = productRepository;
    }

    public async Task<CheckoutResponse> CheckoutAsync(CreateOrderRequest request)
    {
        var cart = await _cartRepository.GetByUserIdAsync(request.UserId);

        if (cart == null || !cart.CartItems.Any())
            throw new Exception("Cart is empty.");

        // Validate inventory
        foreach (var item in cart.CartItems)
        {
            var inventory = await _inventoryRepository.GetByProductIdAsync(item.ProductId);

            if (inventory == null)
                throw new Exception($"Inventory not found for {item.Product.Name}.");

            if (inventory.QuantityInStock < item.Quantity)
                throw new Exception($"Not enough stock for {item.Product.Name}.");
        }

        // Calculate total
        decimal subtotal = cart.CartItems.Sum(x => x.PriceAtPurchase * x.Quantity);

        // Create order
        var order = new Order
        {
            UserId = request.UserId,
            AddressId = request.AddressId,
            OrderDate = DateTime.UtcNow,
            Status = "Pending",
            PaymentStatus = "Pending",
            DeliveryFee = request.DeliveryFee,
            Notes = request.Notes,
            TotalAmount = subtotal + request.DeliveryFee
        };

        await _orderRepository.AddAsync(order);
        await _orderRepository.SaveChangesAsync();

        // Create order items
        var orderItems = cart.CartItems.Select(item => new OrderItem
        {
            OrderId = order.Id,
            ProductId = item.ProductId,
            Quantity = item.Quantity,
            Price = item.PriceAtPurchase
        }).ToList();

        await _orderRepository.AddOrderItemsAsync(orderItems);
        await _orderRepository.SaveChangesAsync();

        // Reduce inventory
        foreach (var item in cart.CartItems)
        {
            var inventory = await _inventoryRepository.GetByProductIdAsync(item.ProductId);

            if (inventory == null)
                throw new Exception($"Inventory not found for {item.Product.Name}.");

            inventory.QuantityInStock -= item.Quantity;
            inventory.LastUpdated = DateTime.UtcNow;

            _inventoryRepository.Update(inventory);
        }

        await _inventoryRepository.SaveChangesAsync();

        // Clear cart
        _cartRepository.DeleteCartItems(cart.CartItems);
        await _cartRepository.SaveChangesAsync();

        return new CheckoutResponse
        {
            OrderId = order.Id,
            TotalAmount = order.TotalAmount,
            Status = order.Status,
            PaymentStatus = order.PaymentStatus
        };
    }

   public async Task<List<OrderResponse>> GetUserOrdersAsync(Guid userId)
{
    var orders = await _orderRepository.GetByUserIdAsync(userId);

    return orders.Select(order => new OrderResponse
    {
        Id = order.Id,
        UserId = order.UserId,
        AddressId = order.AddressId,
        OrderDate = order.OrderDate,
        Status = order.Status,
        TotalAmount = order.TotalAmount,
        DeliveryFee = order.DeliveryFee,
        PaymentStatus = order.PaymentStatus,
        Notes = order.Notes,
        Items = order.OrderItems.Select(item => new OrderItemResponse
        {
            ProductId = item.ProductId,
            ProductName = item.Product.Name,
            Quantity = item.Quantity,
            UnitPrice = item.Price,
            TotalPrice = item.Price * item.Quantity
        }).ToList()
    }).ToList();
}

   public async Task<OrderResponse> GetOrderByIdAsync(Guid id)
{
    var order = await _orderRepository.GetByIdAsync(id);

    if (order == null)
        throw new Exception("Order not found.");

    return new OrderResponse
    {
        Id = order.Id,
        UserId = order.UserId,
        AddressId = order.AddressId,
        OrderDate = order.OrderDate,
        Status = order.Status,
        TotalAmount = order.TotalAmount,
        DeliveryFee = order.DeliveryFee,
        PaymentStatus = order.PaymentStatus,
        Notes = order.Notes,
        Items = order.OrderItems.Select(item => new OrderItemResponse
        {
            ProductId = item.ProductId,
            ProductName = item.Product.Name,
            Quantity = item.Quantity,
            UnitPrice = item.Price,
            TotalPrice = item.Price * item.Quantity
        }).ToList()
    };
}

   public async Task<OrderResponse> UpdateOrderStatusAsync(
    Guid id,
    UpdateOrderStatusRequest request)
{
    var order = await _orderRepository.GetByIdAsync(id);

    if (order == null)
        throw new Exception("Order not found.");

    order.Status = request.Status;

    _orderRepository.Update(order);
    await _orderRepository.SaveChangesAsync();

    return await GetOrderByIdAsync(id);
}
}