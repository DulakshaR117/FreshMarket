using FreshMarket.Application.DTOs.Products;
using FreshMarket.Application.Interfaces;
using FreshMarket.Domain.Entities;

namespace FreshMarket.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public ProductService(
        IProductRepository productRepository,
        ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<List<ProductResponse>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync();

        return products.Select(p => new ProductResponse
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            //StockQuantity = p.StockQuantity,
            CategoryId = p.CategoryId,
            CategoryName = p.Category.Name
        }).ToList();
    }

   public async Task<ProductResponse> GetByIdAsync(Guid id)
{
    var product = await _productRepository.GetByIdAsync(id);

    if (product == null)
        throw new Exception("Product not found.");

    return new ProductResponse
    {
        Id = product.Id,
        Name = product.Name,
        Description = product.Description,
        Price = product.Price,
        // product.StockQuantity,
        CategoryId = product.CategoryId,
        CategoryName = product.Category.Name
    };
}

    public async Task<ProductResponse> CreateAsync(CreateProductRequest request)
    {
        var existing = await _productRepository.GetByNameAsync(request.Name);

        if (existing != null)
            throw new Exception("Product already exists.");

        var category = await _categoryRepository.GetByIdAsync(request.CategoryId);

        if (category == null)
            throw new Exception("Category not found.");

        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
           // StockQuantity = request.StockQuantity,
            CategoryId = request.CategoryId
        };

        await _productRepository.AddAsync(product);
        await _productRepository.SaveChangesAsync();

        return await GetByIdAsync(product.Id);
    }

    public async Task<ProductResponse> UpdateAsync(Guid id, UpdateProductRequest request)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product == null)
            throw new Exception("Product not found.");

        var category = await _categoryRepository.GetByIdAsync(request.CategoryId);

        if (category == null)
            throw new Exception("Category not found.");

        product.Name = request.Name;
        product.Description = request.Description;
        product.Price = request.Price;
        //product.StockQuantity = request.StockQuantity;
        product.CategoryId = request.CategoryId;

        _productRepository.Update(product);
        await _productRepository.SaveChangesAsync();

        return await GetByIdAsync(product.Id);
    }

    public async Task DeleteAsync(Guid id)
    {
        var product = await _productRepository.GetByIdAsync(id);

        if (product == null)
            throw new Exception("Product not found.");

        _productRepository.Delete(product);
        await _productRepository.SaveChangesAsync();
    }
}