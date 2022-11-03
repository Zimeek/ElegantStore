namespace ElegantStore.Api.Exceptions;

public class ProductNotFoundException : Exception
{
    public ProductNotFoundException(int productId)
        : base($"Couldn't find product with id '{productId}'")
    {
        
    }
}