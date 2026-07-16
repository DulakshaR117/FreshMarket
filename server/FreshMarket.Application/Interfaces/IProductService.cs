using FreshMarket.Application.DTOs.Products;

namespace FreshMarket.Application.Interfaces;

public interface IProductService
{
    Task<List<ProductResponse>> GetAllAsync();

    Task<ProductResponse> GetByIdAsync(Guid id);

    Task<ProductResponse> CreateAsync(CreateProductRequest request);

    Task<ProductResponse> UpdateAsync(Guid id, UpdateProductRequest request);

    Task DeleteAsync(Guid id);
}