namespace ElegantStore.Api.Requests;

public record AddCartItemRequest
{
    public int ProductId { get; init; }
    public int Quantity { get; init; }
}