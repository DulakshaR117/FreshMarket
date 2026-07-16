using FreshMarket.Application.Interfaces;
using FreshMarket.Domain.Entities;
using FreshMarket.Infrastructure.Data;

namespace FreshMarket.Infrastructure.Repositories;

public class ProductImageRepository : IProductImageRepository
{
    private readonly ApplicationDbContext _context;

    public ProductImageRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ProductImage> AddAsync(ProductImage image)
    {
        await _context.ProductImages.AddAsync(image);
        return image;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}