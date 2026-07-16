using FreshMarket.Application.DTOs.Cart;
using FreshMarket.Application.Interfaces;
using FreshMarket.Domain.Entities;

namespace FreshMarket.Application.Services;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;

    private readonly IUserRepository _userRepository;

  public CartService(
    ICartRepository cartRepository,
    IProductRepository productRepository,
    IUserRepository userRepository)
{
    _cartRepository = cartRepository;
    _productRepository = productRepository;
    _userRepository = userRepository;
}

   public async Task<CartResponse> GetCartAsync(Guid userId)
{
    var cart = await _cartRepository.GetByUserIdAsync(userId);

    if (cart == null)
    {
        return new CartResponse
        {
            UserId = userId,
            Items = new List<CartItemResponse>()
        };
    }

    return new CartResponse
    {
        Id = cart.Id,
        UserId = cart.UserId,
        Items = cart.CartItems.Select(x => new CartItemResponse
        {
            Id = x.Id,
            ProductId = x.ProductId,
            ProductName = x.Product.Name,
            Price = x.PriceAtPurchase,
            Quantity = x.Quantity
        }).ToList()
    };
}

    public async Task<CartResponse> AddToCartAsync(AddToCartRequest request)
{
    var product = await _productRepository.GetByIdAsync(request.ProductId);

    if (product == null)
        throw new Exception("Product not found.");

    var cart = await _cartRepository.GetByUserIdAsync(request.UserId);

    if (cart == null)
    {
        cart = new Cart
        {
            UserId = request.UserId
        };

        await _cartRepository.AddAsync(cart);
        await _cartRepository.SaveChangesAsync();
    }

    var existingItem = cart.CartItems
        .FirstOrDefault(x => x.ProductId == request.ProductId);

    if (existingItem != null)
    {
        existingItem.Quantity += request.Quantity;
    }
    else
    {
        var cartItem = new CartItem
        {
            CartId = cart.Id,
            ProductId = product.Id,
            Quantity = request.Quantity,
            PriceAtPurchase = product.Price
        };

        await _cartRepository.AddCartItemAsync(cartItem);
    }

    await _cartRepository.SaveChangesAsync();

    return await GetCartAsync(request.UserId);
}

   public async Task<CartResponse> UpdateCartItemAsync(Guid cartItemId, UpdateCartItemRequest request)
{
    var cartItem = await _cartRepository.GetCartItemByIdAsync(cartItemId);

    if (cartItem == null)
        throw new Exception("Cart item not found.");

    cartItem.Quantity = request.Quantity;

    await _cartRepository.UpdateCartItemAsync(cartItem);
    await _cartRepository.SaveChangesAsync();

    return await GetCartAsync(cartItem.Cart.UserId);
}

    public async Task RemoveItemAsync(Guid cartItemId)
{
    var cartItem = await _cartRepository.GetCartItemByIdAsync(cartItemId);

    if (cartItem == null)
        throw new Exception("Cart item not found.");

    _cartRepository.DeleteCartItem(cartItem);

    await _cartRepository.SaveChangesAsync();
}

   public async Task ClearCartAsync(Guid userId)
{
    var cart = await _cartRepository.GetByUserIdAsync(userId);

    if (cart == null)
        return;

    foreach (var item in cart.CartItems.ToList())
    {
        _cartRepository.DeleteCartItem(item);
    }

    await _cartRepository.SaveChangesAsync();
}
}