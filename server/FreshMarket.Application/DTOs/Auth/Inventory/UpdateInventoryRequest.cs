namespace FreshMarket.Application.DTOs.Inventory;

public class UpdateInventoryRequest
{
    public int QuantityInStock { get; set; }

    public int ReorderLevel { get; set; }
}