namespace ElegantStore.Api.Exceptions;

public class ProductAlreadyInCartException : Exception
{
    public ProductAlreadyInCartException(int productId)
        : base($"Product with id '{productId}' is already in cart.")
    {
        
    }
}