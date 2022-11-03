using Ardalis.GuardClauses;
using AutoMapper;
using ElegantStore.Api.DTOs;
using ElegantStore.Api.Exceptions;
using ElegantStore.Domain.Entities.Aggregates.ProductAggregate;
using ElegantStore.Domain.Interfaces;
using ElegantStore.Domain.Specifications;

namespace ElegantStore.Api.Services;

public class ProductService : IProductService
{
    private readonly IRepository<Product> _productRepository;
    private readonly IMapper _mapper;

    public ProductService(
        IRepository<Product> productRepository,
        IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    
    public async Task<ICollection<ProductDTO>> GetProductsAsync()
    {
        var products = await _productRepository.ListAsync();

        return _mapper.Map<ICollection<Product>, ICollection<ProductDTO>>(products);
    }

    public async Task<ProductFullDTO> GetProductWithColorVariantsByIdAsync(int productId)
    {
        var spec = new ProductWithColorVariantsByIdSpec(productId);
        var product = await _productRepository.FirstOrDefaultAsync(spec);

        if (product is null)
        {
            throw new ProductNotFoundException(productId);
        }

        return _mapper.Map<Product, ProductFullDTO>(product);
    }

    public async Task<ICollection<ProductDTO>> GetProductsPagedAsync(int page, int pageSize)
    {
        var spec = new ProductsPagedSpec(page, pageSize);
        var products = await _productRepository.ListAsync(spec);

        return _mapper.Map<ICollection<Product>, ICollection<ProductDTO>>(products);
    }
}