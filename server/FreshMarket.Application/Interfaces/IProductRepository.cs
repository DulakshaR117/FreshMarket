using FreshMarket.Domain.Entities;

namespace FreshMarket.Application.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();

    Task<Product?> GetByIdAsync(Guid id);

    Task<Product?> GetByNameAsync(string name);

    Task AddAsync(Product product);

    void Update(Product product);

    void Delete(Product product);

    Task SaveChangesAsync();
}