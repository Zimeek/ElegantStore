using Ardalis.Specification;
using ElegantStore.Domain.Entities.Aggregates.ProductAggregate;

namespace ElegantStore.Domain.Specifications;

public class FeaturedProductsSpec : Specification<Product>
{
    public FeaturedProductsSpec()
    {
        Query
            .OrderBy(p => Guid.NewGuid())
            .Take(4);
    }
}