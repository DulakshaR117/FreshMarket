using FreshMarket.Domain.Entities;

namespace FreshMarket.Application.Interfaces;

public interface IProductImageRepository
{
    Task<ProductImage> AddAsync(ProductImage image);

    Task SaveChangesAsync();
}