using Ardalis.Specification;
using ElegantStore.Domain.Entities.Aggregates.ProductAggregate;

namespace ElegantStore.Domain.Specifications;

public class ProductsCountByGenderSpec : Specification<Product>
{
    public ProductsCountByGenderSpec(string gender)
    {
        Query
            .Where(product => product.Gender == gender);
    }
}