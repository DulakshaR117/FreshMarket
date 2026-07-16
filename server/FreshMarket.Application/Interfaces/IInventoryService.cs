using FreshMarket.Application.DTOs.Inventory;

namespace FreshMarket.Application.Interfaces;

public interface IInventoryService
{
    Task<List<InventoryResponse>> GetAllAsync();

    Task<InventoryResponse> GetByIdAsync(Guid id);

    Task<InventoryResponse> CreateAsync(CreateInventoryRequest request);

    Task<InventoryResponse> UpdateAsync(Guid id, UpdateInventoryRequest request);

    Task<InventoryResponse> IncreaseStockAsync(Guid id, StockAdjustmentRequest request);

    Task<InventoryResponse> DecreaseStockAsync(Guid id, StockAdjustmentRequest request);

    Task DeleteAsync(Guid id);
}