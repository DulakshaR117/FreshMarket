namespace FreshMarket.Application.DTOs.Addresses;

public class AddressSummaryResponse
{
    public Guid Id { get; set; }

    public string AddressLine1 { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public bool IsDefault { get; set; }
}