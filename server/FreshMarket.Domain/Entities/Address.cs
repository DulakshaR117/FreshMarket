using FreshMarket.Domain.Common;

namespace FreshMarket.Domain.Entities;

public class Address : BaseEntity
{
    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    public string AddressLine1 { get; set; } = string.Empty;

    public string? AddressLine2 { get; set; }

    public string City { get; set; } = string.Empty;

    public string District { get; set; } = string.Empty;

    public string Province { get; set; } = string.Empty;

    public string PostalCode { get; set; } = string.Empty;

    public bool IsDefault { get; set; }
}