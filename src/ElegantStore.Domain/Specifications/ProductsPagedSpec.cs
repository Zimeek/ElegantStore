using Ardalis.Specification;
using ElegantStore.Domain.Entities.Aggregates.ProductAggregate;

namespace ElegantStore.Domain.Specifications;

public class ProductsPagedSpec : Specification<Product>
{
    public ProductsPagedSpec(int page, int pageSize, string gender)
    {
        Query
            .Where(product => product.Gender == gender)
            .Skip((page - 1) * pageSize)
            .Take(pageSize);
    }
}