using FreshMarket.Application.DTOs.Categories;
using FreshMarket.Application.Interfaces;
using FreshMarket.Domain.Entities;

namespace FreshMarket.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<CategoryResponse>> GetAllAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();

        return categories.Select(c => new CategoryResponse
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description,
            CreatedAt = c.CreatedAt
        });
    }

    public async Task<CategoryResponse?> GetByIdAsync(Guid id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);

        if (category == null)
            return null;

        return new CategoryResponse
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
            CreatedAt = category.CreatedAt
        };
    }

    public async Task<CategoryResponse> CreateAsync(CreateCategoryRequest request)
    {
        var exists = await _categoryRepository.GetByNameAsync(request.Name);

        if (exists != null)
            throw new Exception("Category already exists.");

        var category = new Category
        {
            Name = request.Name,
            Description = request.Description ?? string.Empty
        };

        await _categoryRepository.AddAsync(category);
        await _categoryRepository.SaveChangesAsync();

        return new CategoryResponse
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
            CreatedAt = category.CreatedAt
        };
    }

    public async Task<CategoryResponse> UpdateAsync(Guid id, UpdateCategoryRequest request)
    {
        var category = await _categoryRepository.GetByIdAsync(id);

        if (category == null)
            throw new Exception("Category not found.");

        category.Name = request.Name;
        category.Description = request.Description ?? string.Empty;

        _categoryRepository.Update(category);
        await _categoryRepository.SaveChangesAsync();

        return new CategoryResponse
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
            CreatedAt = category.CreatedAt
        };
    }

    public async Task DeleteAsync(Guid id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);

        if (category == null)
            throw new Exception("Category not found.");

        _categoryRepository.Delete(category);
        await _categoryRepository.SaveChangesAsync();
    }
}