using Ardalis.GuardClauses;
using ElegantStore.Domain.Interfaces;

namespace ElegantStore.Domain.Entities.Aggregates.ProductAggregate;

public class Product : BaseEntity<int>, IAggregateRoot
{
    private Product() { }

    public Product(int id, string brand, string model, string color, string imageBase, decimal price)
    {
        Guard.Against.NegativeOrZero(id, nameof(id));
        Guard.Against.NullOrWhiteSpace(brand, nameof(brand));
        Guard.Against.NullOrWhiteSpace(model, nameof(model));
        Guard.Against.NullOrWhiteSpace(color, nameof(color));
        Guard.Against.NullOrWhiteSpace(imageBase, nameof(imageBase));
        Guard.Against.NegativeOrZero(price, nameof(price));

        Id = id;
        Brand = brand;
        Model = model;
        Color = color;
        ImageBase = imageBase;
        Price = price;

    }
    
    public string Brand { get; private set; }
    public string Model { get; private set; }
    public string Color { get; private set; }
    public string ImageBase { get; private set; }
    public decimal Price { get; private set; }
    public ICollection<ProductColor> ColorVariants { get; private set; } = new List<ProductColor>();
}