using FreshMarket.Domain.Common;

namespace FreshMarket.Domain.Entities;

public class Order : BaseEntity
{
    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    public Guid AddressId { get; set; }

    public Address Address { get; set; } = null!;

    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    public string Status { get; set; } = "Pending";

    public decimal TotalAmount { get; set; }

    public decimal DeliveryFee { get; set; }

    public string PaymentStatus { get; set; } = "Pending";

    public string? Notes { get; set; }

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}