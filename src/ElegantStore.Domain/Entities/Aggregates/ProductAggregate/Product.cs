using Ardalis.GuardClauses;
using ElegantStore.Domain.Interfaces;

namespace ElegantStore.Domain.Entities.Aggregates.ProductAggregate;

public class Product : BaseEntity<int>, IAggregateRoot
{
    private Product() { }

    public Product(int id, string brand, string model, string image, decimal price)
    {
        Guard.Against.NegativeOrZero(id, nameof(id));
        Guard.Against.NullOrWhiteSpace(brand, nameof(brand));
        Guard.Against.NullOrWhiteSpace(model, nameof(model));
        Guard.Against.NullOrWhiteSpace(image, nameof(image));
        Guard.Against.NegativeOrZero(price, nameof(price));

        Id = id;
        Brand = brand;
        Model = model;
        Image = image;
        Price = price;

    }
    
    public string Brand { get; private set; }
    public string Model { get; private set; }
    public string Image { get; private set; }
    public decimal Price { get; private set; }
    public ICollection<ProductColor> Colors { get; private set; } = new List<ProductColor>();
}