using FreshMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreshMarket.Infrastructure.Configurations;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Product)
            .WithMany(x => x.CartItems)
            .HasForeignKey(x => x.ProductId);

        builder.Property(x => x.Quantity)
            .IsRequired();

        builder.Property(x => x.PriceAtPurchase)
            .HasColumnType("decimal(18,2)");
    }
}