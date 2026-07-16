using FreshMarket.Application.Interfaces;
using FreshMarket.Domain.Entities;
using FreshMarket.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FreshMarket.Infrastructure.Repositories;

public class InventoryRepository : IInventoryRepository
{
    private readonly ApplicationDbContext _context;

    public InventoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Inventory>> GetAllAsync()
    {
        return await _context.Inventories
            .Include(i => i.Product)
            .ToListAsync();
    }

    public async Task<Inventory?> GetByIdAsync(Guid id)
    {
        return await _context.Inventories
            .Include(i => i.Product)
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<Inventory?> GetByProductIdAsync(Guid productId)
    {
        return await _context.Inventories
            .Include(i => i.Product)
            .FirstOrDefaultAsync(i => i.ProductId == productId);
    }

    public async Task AddAsync(Inventory inventory)
    {
        await _context.Inventories.AddAsync(inventory);
    }

    public void Update(Inventory inventory)
    {
        _context.Inventories.Update(inventory);
    }

    public void Delete(Inventory inventory)
    {
        _context.Inventories.Remove(inventory);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}