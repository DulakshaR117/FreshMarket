using FreshMarket.Domain.Entities;

namespace FreshMarket.Application.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync();

    Task<Category?> GetByIdAsync(Guid id);

    Task<Category?> GetByNameAsync(string name);

    Task AddAsync(Category category);

    void Update(Category category);

    void Delete(Category category);

    Task SaveChangesAsync();
}