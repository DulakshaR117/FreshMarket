using FreshMarket.Application.Interfaces;
using FreshMarket.Domain.Entities;
using FreshMarket.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FreshMarket.Infrastructure.Repositories;

public class AddressRepository : IAddressRepository
{
    private readonly ApplicationDbContext _context;

    public AddressRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Address>> GetByUserIdAsync(Guid userId)
    {
        return await _context.Addresses
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }

    public async Task<Address?> GetByIdAsync(Guid id)
    {
        return await _context.Addresses
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Address address)
    {
        await _context.Addresses.AddAsync(address);
    }

    public void Update(Address address)
    {
        _context.Addresses.Update(address);
    }

    public void Delete(Address address)
    {
        _context.Addresses.Remove(address);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}