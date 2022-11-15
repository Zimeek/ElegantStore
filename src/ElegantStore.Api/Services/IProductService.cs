using ElegantStore.Api.DTOs;

namespace ElegantStore.Api.Services;

public interface IProductService
{
    Task<ICollection<ProductDTO>> GetProductsAsync();
    Task<ICollection<ProductDTO>> GetProductsPagedAsync(int page, int pageSize, string gender);
    Task<ProductFullDTO> GetProductWithColorVariantsByIdAsync(int productId);
    Task<ICollection<ProductDTO>> GetFeaturedProductsAsync();
}