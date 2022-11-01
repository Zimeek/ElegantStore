using Ardalis.Specification;
using ElegantStore.Domain.Entities.Aggregates.ProductAggregate;

namespace ElegantStore.Domain.Specifications;

public class ProductsWithColorVariantsSpec : Specification<Product>
{
    public ProductsWithColorVariantsSpec()
    {
        Query
            .Include(product => product.ColorVariants)
            .ThenInclude(variant => variant.Color);
    }
}