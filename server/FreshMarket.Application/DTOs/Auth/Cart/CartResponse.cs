namespace FreshMarket.Application.DTOs.Cart;

public class CartResponse
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public List<CartItemResponse> Items { get; set; } = [];

    public decimal GrandTotal => Items.Sum(x => x.Total);
}