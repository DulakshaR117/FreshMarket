using FreshMarket.Domain.Common;

namespace FreshMarket.Domain.Entities;

public class Product : BaseEntity
{
    public Guid CategoryId { get; set; }

    public Category Category { get; set; } = null!;

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public decimal? DiscountPrice { get; set; }

    public string Unit { get; set; } = string.Empty;

    public string? ThumbnailUrl { get; set; }

    public bool IsFeatured { get; set; }

    public bool IsAvailable { get; set; } = true;

    // Fresh produce fields
    public string Origin { get; set; } = string.Empty;

    public DateTime? HarvestDate { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public bool IsOrganic { get; set; }

    public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();

    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
}