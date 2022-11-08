namespace ElegantStore.Api.DTOs;

public record ProductFullDTO
{
    public int Id { get; init; }
    public string Brand { get; init; }
    public string Model { get; init; }
    public string Color { get; init; }
    public string Gender { get; init; }
    public string ImageBase { get; init; }
    public decimal Price { get; init; }
    public ICollection<ProductVariantDTO> Variants { get; init; }
}