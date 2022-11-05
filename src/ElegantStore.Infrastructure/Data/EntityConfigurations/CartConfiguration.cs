using ElegantStore.Domain.Entities.Aggregates.CartAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElegantStore.Infrastructure.Data.EntityConfigurations;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.HasKey(cart => cart.Id);
        builder.Property(cart => cart.Id)
            .ValueGeneratedOnAdd();

        builder.HasMany(cart => cart.Items)
            .WithOne(cartItem => cartItem.Cart)
            .HasForeignKey(cartItem => cartItem.CartId);

        builder.ToTable("Carts");
    }
}