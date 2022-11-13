namespace ElegantStore.Api.DTOs;

public record CartItemDTO
{
    public string Id { get; init; }
    public int ProductId { get; init; }
    public int Quantity { get; init; }
    public string Color { get; init; }
}