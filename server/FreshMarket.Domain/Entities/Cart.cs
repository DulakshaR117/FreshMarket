using FreshMarket.Domain.Common;

namespace FreshMarket.Domain.Entities;

public class Cart : BaseEntity
{
    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
}