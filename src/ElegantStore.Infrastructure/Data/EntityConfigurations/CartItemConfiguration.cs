using ElegantStore.Domain.Entities.Aggregates.CartAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElegantStore.Infrastructure.Data.EntityConfigurations;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.HasKey(cartItem => cartItem.Id);
        builder.Property(cartItem => cartItem.Id)
            .ValueGeneratedOnAdd();

        builder.ToTable("CartItems");
    }
}