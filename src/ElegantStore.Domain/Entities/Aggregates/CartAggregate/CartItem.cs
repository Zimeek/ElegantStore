using Ardalis.GuardClauses;
using ElegantStore.Domain.Entities.Aggregates.ProductAggregate;

namespace ElegantStore.Domain.Entities.Aggregates.CartAggregate;

public class CartItem : BaseEntity<string>
{
    private CartItem()
    {
        
    }

    public CartItem(string cartId, int productId, int quantity, decimal price, string color)
    {
        Guard.Against.NullOrWhiteSpace(cartId, nameof(cartId));
        Guard.Against.NegativeOrZero(productId, nameof(productId));
        Guard.Against.NegativeOrZero(quantity, nameof(quantity));
        Guard.Against.NegativeOrZero(price, nameof(price));
        Guard.Against.NullOrWhiteSpace("color", nameof(color));

        CartId = cartId;
        ProductId = productId;
        Quantity = quantity;
        Price = price;
        Color = color;
    }
    
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }
    public int ProductId { get; private set; }
    public Product Product { get; private set; }
    public string Color { get; private set; }
    public string CartId { get; private set; }
    public Cart Cart { get; private set; }

    public void UpdateQuantity(int quantity)
    {
        Quantity = quantity;
    }
}