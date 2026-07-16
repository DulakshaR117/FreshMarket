namespace FreshMarket.Application.DTOs.Orders;

public class OrderResponse
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid AddressId { get; set; }

    public DateTime OrderDate { get; set; }

    public string Status { get; set; } = string.Empty;

    public decimal TotalAmount { get; set; }

    public decimal DeliveryFee { get; set; }

    public string PaymentStatus { get; set; } = string.Empty;

    public string? Notes { get; set; }

    public List<OrderItemResponse> Items { get; set; } = new();
}