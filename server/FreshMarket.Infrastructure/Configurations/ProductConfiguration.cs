using FreshMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FreshMarket.Infrastructure.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
               .HasMaxLength(150)
               .IsRequired();

        builder.Property(x => x.Price)
               .HasColumnType("decimal(18,2)");

        builder.HasOne(x => x.Category)
               .WithMany(c => c.Products)
               .HasForeignKey(x => x.CategoryId);
    }
}