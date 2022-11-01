using ElegantStore.Domain.Entities.Aggregates.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElegantStore.Infrastructure.Data.EntityConfigurations;

public class ProductColorConfiguration : IEntityTypeConfiguration<ProductColor>
{
    public void Configure(EntityTypeBuilder<ProductColor> builder)
    {
        builder.HasKey(productColor => new {productColor.ProductId, productColor.ColorId});
        builder.ToTable("ProductColors");
    }
}