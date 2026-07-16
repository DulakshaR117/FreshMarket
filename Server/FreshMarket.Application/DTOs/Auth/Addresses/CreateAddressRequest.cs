namespace FreshMarket.Application.DTOs.Addresses;

public class CreateAddressRequest
{
    public Guid UserId { get; set; }

    public string AddressLine1 { get; set; } = string.Empty;

    public string? AddressLine2 { get; set; }

    public string City { get; set; } = string.Empty;

    public string District { get; set; } = string.Empty;

    public string Province { get; set; } = string.Empty;

    public string PostalCode { get; set; } = string.Empty;

    public bool IsDefault { get; set; }
}