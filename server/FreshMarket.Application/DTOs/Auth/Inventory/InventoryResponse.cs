namespace FreshMarket.Application.DTOs.Inventory;

public class InventoryResponse
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public int QuantityInStock { get; set; }

    public int ReorderLevel { get; set; }

    public DateTime LastUpdated { get; set; }

    public bool IsLowStock => QuantityInStock <= ReorderLevel;
}