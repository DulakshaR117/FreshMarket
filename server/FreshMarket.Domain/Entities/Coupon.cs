using FreshMarket.Domain.Common;

namespace FreshMarket.Domain.Entities;

public class Coupon : BaseEntity
{
    public string Code { get; set; } = string.Empty;

    public string DiscountType { get; set; } = "Percentage";

    public decimal DiscountValue { get; set; }

    public decimal MinimumOrder { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public bool IsActive { get; set; } = true;
}