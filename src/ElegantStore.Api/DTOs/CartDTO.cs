namespace ElegantStore.Api.DTOs;

public record CartDTO
{
    public string Id { get; init; }
    public ICollection<CartItemDTO> Items { get; init; }
}