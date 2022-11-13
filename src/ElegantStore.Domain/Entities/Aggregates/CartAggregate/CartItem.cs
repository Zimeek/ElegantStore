using Ardalis.GuardClauses;
using ElegantStore.Domain.Entities.Aggregates.ProductAggregate;

namespace ElegantStore.Domain.Entities.Aggregates.CartAggregate;

public class CartItem : BaseEntity<string>
{
    private CartItem()
    {
        
    }

    public CartItem(string cartId, int productId, int quantity, string color)
    {
        Guard.Against.NullOrWhiteSpace(cartId, nameof(cartId));
        Guard.Against.NegativeOrZero(productId, nameof(productId));
        Guard.Against.NegativeOrZero(quantity, nameof(quantity));
        Guard.Against.NullOrWhiteSpace("color", nameof(color));

        CartId = cartId;
        ProductId = productId;
        Quantity = quantity;
        Color = color;
    }
    
    public int Quantity { get; set; }
    public int ProductId { get; private set; }
    public Product Product { get; private set; }
    public string Color { get; private set; }
    public string CartId { get; private set; }
    public Cart Cart { get; private set; }

    public void AddQuantity()
    {
        Quantity += 1;
    }
}