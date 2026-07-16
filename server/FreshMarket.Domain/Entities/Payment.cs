using FreshMarket.Domain.Common;

namespace FreshMarket.Domain.Entities;

public class Payment : BaseEntity
{
    public Guid OrderId { get; set; }

    public Order Order { get; set; } = null!;

    public string Method { get; set; } = string.Empty;

    public decimal Amount { get; set; }

    public string? TransactionId { get; set; }

    public string Status { get; set; } = "Pending";

    public DateTime? PaidAt { get; set; }
}