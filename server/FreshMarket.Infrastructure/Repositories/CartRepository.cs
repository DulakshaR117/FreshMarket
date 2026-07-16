using FreshMarket.Application.Interfaces;
using FreshMarket.Domain.Entities;
using FreshMarket.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FreshMarket.Infrastructure.Repositories;

public class CartRepository : ICartRepository
{
    private readonly ApplicationDbContext _context;

    public CartRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Cart?> GetByUserIdAsync(Guid userId)
    {
        return await _context.Carts
            .Include(c => c.CartItems)
            .ThenInclude(ci => ci.Product)
            .FirstOrDefaultAsync(c => c.UserId == userId);
    }

    public async Task<CartItem?> GetCartItemByIdAsync(Guid cartItemId)
    {
        return await _context.CartItems
            .Include(ci => ci.Product)
            .FirstOrDefaultAsync(ci => ci.Id == cartItemId);
    }

    public async Task AddAsync(Cart cart)
    {
        await _context.Carts.AddAsync(cart);
    }

    public async Task AddCartItemAsync(CartItem cartItem)
    {
        await _context.CartItems.AddAsync(cartItem);
    }

    public Task UpdateCartItemAsync(CartItem cartItem)
    {
        _context.CartItems.Update(cartItem);
        return Task.CompletedTask;
    }

    public void Update(Cart cart)
    {
        _context.Carts.Update(cart);
    }

    public void Delete(Cart cart)
    {
        _context.Carts.Remove(cart);
    }

    public void DeleteCartItem(CartItem cartItem)
    {
        _context.CartItems.Remove(cartItem);
    }

    public void DeleteCartItems(IEnumerable<CartItem> cartItems)
{
    _context.CartItems.RemoveRange(cartItems);
}

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}