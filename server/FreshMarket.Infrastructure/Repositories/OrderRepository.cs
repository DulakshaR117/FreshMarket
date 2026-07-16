using FreshMarket.Application.Interfaces;
using FreshMarket.Domain.Entities;
using FreshMarket.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FreshMarket.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Order>> GetAllAsync()
    {
        return await _context.Orders
            .Include(o => o.User)
            .Include(o => o.Address)
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
            .ToListAsync();
    }

    public async Task<List<Order>> GetByUserIdAsync(Guid userId)
    {
        return await _context.Orders
            .Include(o => o.Address)
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
            .Where(o => o.UserId == userId)
            .ToListAsync();
    }

    public async Task<Order?> GetByIdAsync(Guid id)
    {
        return await _context.Orders
            .Include(o => o.User)
            .Include(o => o.Address)
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
    }

    public async Task AddOrderItemAsync(OrderItem orderItem)
{
    await _context.OrderItems.AddAsync(orderItem);
}

public async Task AddOrderItemsAsync(IEnumerable<OrderItem> orderItems)
{
    await _context.OrderItems.AddRangeAsync(orderItems);
}

    public void Update(Order order)
    {
        _context.Orders.Update(order);
    }

    public void Delete(Order order)
    {
        _context.Orders.Remove(order);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}