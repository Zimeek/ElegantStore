namespace ElegantStore.Api.DTOs;

public record ProductDTO
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public string ImageBase { get; set; }
    public decimal Price { get; set; }
}