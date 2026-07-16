using FreshMarket.Domain.Entities;

namespace FreshMarket.Application.Interfaces;

public interface IAddressRepository
{
    Task<List<Address>> GetByUserIdAsync(Guid userId);

    Task<Address?> GetByIdAsync(Guid id);

    Task AddAsync(Address address);

    void Update(Address address);

    void Delete(Address address);

    Task SaveChangesAsync();
}