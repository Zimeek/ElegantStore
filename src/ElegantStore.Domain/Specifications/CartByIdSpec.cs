using Ardalis.Specification;
using ElegantStore.Domain.Entities.Aggregates.CartAggregate;

namespace ElegantStore.Domain.Specifications;

public class CartByIdSpec : Specification<Cart>
{
    public CartByIdSpec(string cartId)
    {
        Query
            .Include(cart => cart.Items)
            .Where(cart => cart.Id == cartId);
    }
}