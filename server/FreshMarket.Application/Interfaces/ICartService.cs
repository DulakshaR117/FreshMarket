using FreshMarket.Application.DTOs.Cart;

namespace FreshMarket.Application.Interfaces;

public interface ICartService
{
    Task<CartResponse> GetCartAsync(Guid userId);

    Task<CartResponse> AddToCartAsync(AddToCartRequest request);

    Task<CartResponse> UpdateCartItemAsync(Guid cartItemId, UpdateCartItemRequest request);

    Task ClearCartAsync(Guid userId);

    Task RemoveItemAsync(Guid cartItemId);
}