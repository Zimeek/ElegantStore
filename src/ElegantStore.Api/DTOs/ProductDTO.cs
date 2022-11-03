namespace ElegantStore.Api.DTOs;

public record ProductDTO
{
    public int Id { get; init; }
    public string Brand { get; init; }
    public string Model { get; init; }
    public string Color { get; init; }
    public string ImageBase { get; init; }
    public decimal Price { get; init; }
}