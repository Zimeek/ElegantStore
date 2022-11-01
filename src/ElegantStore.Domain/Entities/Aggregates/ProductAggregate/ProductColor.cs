using Ardalis.GuardClauses;

namespace ElegantStore.Domain.Entities.Aggregates.ProductAggregate;

public class ProductColor
{
    private ProductColor() { }

    public ProductColor(int productId, int colorId)
    {
        Guard.Against.NegativeOrZero(productId, nameof(productId));
        Guard.Against.NegativeOrZero(colorId, nameof(colorId));

        ProductId = productId;
        ColorId = colorId;
    }
    
    public int ProductId { get; private set; }
    public Product Product { get; private set; }
    public int ColorId { get; private set; }
    public Color Color { get; private set; }
}