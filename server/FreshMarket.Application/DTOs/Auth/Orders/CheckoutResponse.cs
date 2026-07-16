namespace FreshMarket.Application.DTOs.Orders;

public class CheckoutResponse
{
    public Guid OrderId { get; set; }

    public decimal TotalAmount { get; set; }

    public string Status { get; set; } = string.Empty;

    public string PaymentStatus { get; set; } = string.Empty;
}