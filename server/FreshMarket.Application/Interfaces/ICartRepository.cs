using FreshMarket.Domain.Entities;

namespace FreshMarket.Application.Interfaces;

public interface ICartRepository
{
    Task<Cart?> GetByUserIdAsync(Guid userId);

    Task<CartItem?> GetCartItemByIdAsync(Guid cartItemId);

    Task AddAsync(Cart cart);

    Task AddCartItemAsync(CartItem cartItem);

    void Update(Cart cart);

    void Delete(Cart cart);

    void DeleteCartItem(CartItem cartItem);

    void DeleteCartItems(IEnumerable<CartItem> cartItems);

    Task SaveChangesAsync();

    Task UpdateCartItemAsync(CartItem cartItem);
}