using ElegantStore.Api.DTOs;

namespace ElegantStore.Api.Services;

public interface IProductService
{
    Task<ICollection<ProductDTO>> GetProductsAsync();
    Task<ICollection<ProductDTO>> GetProductsPagedAsync(int page, int pageSize);
    Task<ProductFullDTO> GetProductWithColorVariantsByIdAsync(int productId);
}