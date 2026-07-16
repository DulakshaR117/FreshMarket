using FreshMarket.Domain.Entities;

namespace FreshMarket.Application.Interfaces;

public interface IRoleRepository
{
    Task<Role?> GetByNameAsync(string name);
}