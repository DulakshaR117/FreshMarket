using FreshMarket.Domain.Entities;

namespace FreshMarket.Application.Interfaces;

public interface IInventoryRepository
{
    Task<List<Inventory>> GetAllAsync();

    Task<Inventory?> GetByIdAsync(Guid id);

    Task<Inventory?> GetByProductIdAsync(Guid productId);

    Task AddAsync(Inventory inventory);

    void Update(Inventory inventory);

    void Delete(Inventory inventory);

    Task SaveChangesAsync();
}