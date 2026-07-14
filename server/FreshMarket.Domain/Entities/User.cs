using FreshMarket.Domain.Common;

namespace FreshMarket.Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string? ProfileImage { get; set; }

    public bool IsActive { get; set; } = true;

    public Guid RoleId { get; set; }

    public Role Role { get; set; } = null!;

    public ICollection<Address> Addresses { get; set; } = new List<Address>();

    public ICollection<Cart> Carts { get; set; } = new List<Cart>();
}