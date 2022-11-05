namespace ElegantStore.Api.Exceptions;

public class CartItemNotFoundException : Exception
{
    public CartItemNotFoundException(string itemId)
        : base($"Couldn't find cart item with id '{itemId}'")
    {
        
    }
}