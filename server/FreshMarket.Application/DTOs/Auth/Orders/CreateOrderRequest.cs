namespace FreshMarket.Application.DTOs.Orders;

public class CreateOrderRequest
{
    public Guid UserId { get; set; }

    public Guid AddressId { get; set; }

    public decimal DeliveryFee { get; set; }

    public string? Notes { get; set; }
}