using ElegantStore.Api.DTOs;
using ElegantStore.Api.Exceptions;
using ElegantStore.Domain.Entities.Aggregates.ProductAggregate;
using ElegantStore.Domain.Interfaces;
using ElegantStore.Domain.Specifications;
using Mapster;

namespace ElegantStore.Api.Services;

public class ProductService : IProductService
{
    private readonly IRepository<Product> _productRepository;

    public ProductService(
        IRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<ICollection<ProductDTO>> GetProductsAsync()
    {
        var products = await _productRepository.ListAsync();

        return products.Adapt<ICollection<ProductDTO>>();
    }

    public async Task<ProductFullDTO> GetProductWithColorVariantsByIdAsync(int productId)
    {
        var spec = new ProductWithColorVariantsByIdSpec(productId);
        var product = await _productRepository.FirstOrDefaultAsync(spec);

        if (product is null)
        {
            throw new ProductNotFoundException(productId);
        }
        
        

        return product.Adapt<ProductFullDTO>();
    }

    public async Task<ICollection<ProductDTO>> GetProductsPagedAsync(int page, int pageSize)
    {
        var spec = new ProductsPagedSpec(page, pageSize);
        var products = await _productRepository.ListAsync(spec);

        return products.Adapt<ICollection<ProductDTO>>();
    }
}