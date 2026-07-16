namespace FreshMarket.Application.DTOs.Inventory;

public class CreateInventoryRequest
{
    public Guid ProductId { get; set; }

    public int QuantityInStock { get; set; }

    public int ReorderLevel { get; set; }
}