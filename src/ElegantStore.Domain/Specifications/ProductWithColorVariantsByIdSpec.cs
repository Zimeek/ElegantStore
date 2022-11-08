using Ardalis.Specification;
using ElegantStore.Domain.Entities.Aggregates.ProductAggregate;

namespace ElegantStore.Domain.Specifications;

public class ProductWithColorVariantsByIdSpec : Specification<Product>, ISingleResultSpecification<Product>
{
    public ProductWithColorVariantsByIdSpec(int productId)
    {
        Query
            .Include(product => product.Variants)
            .ThenInclude(colorVariants => colorVariants.Color)
            .Where(product => product.Id == productId);
    }
}