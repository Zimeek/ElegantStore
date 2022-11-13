namespace ElegantStore.Api.Requests;

public record UpdateCartItemRequest
{
    public string ItemId { get; init; }
}