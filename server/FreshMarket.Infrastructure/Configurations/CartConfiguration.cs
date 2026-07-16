using FreshMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreshMarket.Infrastructure.Configurations;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.User)
            .WithMany(x => x.Carts)
            .HasForeignKey(x => x.UserId);

        builder.HasMany(x => x.CartItems)
            .WithOne(x => x.Cart)
            .HasForeignKey(x => x.CartId);
    }
}