using FreshMarket.Application.DTOs.Inventory;
using FreshMarket.Application.Interfaces;
using FreshMarket.Domain.Entities;

namespace FreshMarket.Application.Services;

public class InventoryService : IInventoryService
{
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IProductRepository _productRepository;

    public InventoryService(
        IInventoryRepository inventoryRepository,
        IProductRepository productRepository)
    {
        _inventoryRepository = inventoryRepository;
        _productRepository = productRepository;
    }

   public async Task<List<InventoryResponse>> GetAllAsync()
{
    var inventories = await _inventoryRepository.GetAllAsync();

    return inventories.Select(i => new InventoryResponse
    {
        Id = i.Id,
        ProductId = i.ProductId,
        ProductName = i.Product.Name,
        QuantityInStock = i.QuantityInStock,
        ReorderLevel = i.ReorderLevel,
        LastUpdated = i.LastUpdated
    }).ToList();
}

  public async Task<InventoryResponse> GetByIdAsync(Guid id)
{
    var inventory = await _inventoryRepository.GetByIdAsync(id);

    if (inventory == null)
        throw new Exception("Inventory not found.");

    return new InventoryResponse
    {
        Id = inventory.Id,
        ProductId = inventory.ProductId,
        ProductName = inventory.Product.Name,
        QuantityInStock = inventory.QuantityInStock,
        ReorderLevel = inventory.ReorderLevel,
        LastUpdated = inventory.LastUpdated
    };
}

 public async Task<InventoryResponse> CreateAsync(CreateInventoryRequest request)
{
    var product = await _productRepository.GetByIdAsync(request.ProductId);

    if (product == null)
        throw new Exception("Product not found.");

    var existingInventory = await _inventoryRepository.GetByProductIdAsync(request.ProductId);

    if (existingInventory != null)
        throw new Exception("Inventory already exists for this product.");

    var inventory = new Inventory
    {
        ProductId = request.ProductId,
        QuantityInStock = request.QuantityInStock,
        ReorderLevel = request.ReorderLevel,
        LastUpdated = DateTime.UtcNow
    };

    await _inventoryRepository.AddAsync(inventory);
    await _inventoryRepository.SaveChangesAsync();

    return await GetByIdAsync(inventory.Id);
}

   public async Task<InventoryResponse> UpdateAsync(Guid id, UpdateInventoryRequest request)
{
    var inventory = await _inventoryRepository.GetByIdAsync(id);

    if (inventory == null)
        throw new Exception("Inventory not found.");

    inventory.QuantityInStock = request.QuantityInStock;
    inventory.ReorderLevel = request.ReorderLevel;
    inventory.LastUpdated = DateTime.UtcNow;

    _inventoryRepository.Update(inventory);
    await _inventoryRepository.SaveChangesAsync();

    return await GetByIdAsync(id);
}

   public async Task<InventoryResponse> IncreaseStockAsync(Guid id, StockAdjustmentRequest request)
{
    var inventory = await _inventoryRepository.GetByIdAsync(id);

    if (inventory == null)
        throw new Exception("Inventory not found.");

    if (request.Quantity <= 0)
        throw new Exception("Quantity must be greater than zero.");

    inventory.QuantityInStock += request.Quantity;
    inventory.LastUpdated = DateTime.UtcNow;

    _inventoryRepository.Update(inventory);
    await _inventoryRepository.SaveChangesAsync();

    return await GetByIdAsync(id);
}

    public async Task<InventoryResponse> DecreaseStockAsync(Guid id, StockAdjustmentRequest request)
{
    var inventory = await _inventoryRepository.GetByIdAsync(id);

    if (inventory == null)
        throw new Exception("Inventory not found.");

    if (request.Quantity <= 0)
        throw new Exception("Quantity must be greater than zero.");

    if (inventory.QuantityInStock < request.Quantity)
        throw new Exception("Not enough stock available.");

    inventory.QuantityInStock -= request.Quantity;
    inventory.LastUpdated = DateTime.UtcNow;

    _inventoryRepository.Update(inventory);
    await _inventoryRepository.SaveChangesAsync();

    return await GetByIdAsync(id);
}

    public async Task DeleteAsync(Guid id)
{
    var inventory = await _inventoryRepository.GetByIdAsync(id);

    if (inventory == null)
        throw new Exception("Inventory not found.");

    _inventoryRepository.Delete(inventory);
    await _inventoryRepository.SaveChangesAsync();
}
}