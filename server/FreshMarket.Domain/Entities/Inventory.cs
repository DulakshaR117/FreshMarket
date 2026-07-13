using FreshMarket.Domain.Common;

namespace FreshMarket.Domain.Entities;

public class Inventory : BaseEntity
{
    public Guid ProductId { get; set; }

    public Product Product { get; set; } = null!;

    public int QuantityInStock { get; set; }

    public int ReorderLevel { get; set; }

    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
}