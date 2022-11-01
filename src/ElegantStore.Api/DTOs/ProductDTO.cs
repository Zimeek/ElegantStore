namespace ElegantStore.Api.DTOs;

public record ProductDTO
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public string ImageBase { get; set; }
    public decimal Price { get; set; }
    public ICollection<ProductColorDTO> ColorVariants { get; set; }
}