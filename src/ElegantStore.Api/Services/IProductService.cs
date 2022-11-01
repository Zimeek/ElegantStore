using ElegantStore.Api.DTOs;

namespace ElegantStore.Api.Services;

public interface IProductService
{
    Task<ICollection<ProductDTO>> GetAllProductsAsync();
}