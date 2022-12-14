namespace ElegantStore.Api.Requests;

public record AddCartItemRequest
{
    public int ProductId { get; init; }
    public decimal Price { get; init; }
    public string Color { get; init; }
}