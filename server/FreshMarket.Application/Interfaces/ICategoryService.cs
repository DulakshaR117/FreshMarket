using FreshMarket.Application.DTOs.Categories;

namespace FreshMarket.Application.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryResponse>> GetAllAsync();

    Task<CategoryResponse?> GetByIdAsync(Guid id);

    Task<CategoryResponse> CreateAsync(CreateCategoryRequest request);

    Task<CategoryResponse> UpdateAsync(Guid id, UpdateCategoryRequest request);

    Task DeleteAsync(Guid id);
}