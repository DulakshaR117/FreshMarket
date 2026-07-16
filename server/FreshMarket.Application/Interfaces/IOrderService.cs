using FreshMarket.Application.DTOs.Orders;

namespace FreshMarket.Application.Interfaces;

public interface IOrderService
{
    Task<CheckoutResponse> CheckoutAsync(CreateOrderRequest request);

    Task<List<OrderResponse>> GetUserOrdersAsync(Guid userId);

    Task<OrderResponse> GetOrderByIdAsync(Guid id);

    Task<OrderResponse> UpdateOrderStatusAsync(Guid id, UpdateOrderStatusRequest request);
}