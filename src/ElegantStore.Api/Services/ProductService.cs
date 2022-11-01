using AutoMapper;
using ElegantStore.Api.DTOs;
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
    
    public async Task<ICollection<ProductDTO>> GetAllProductsAsync()
    {
        var spec = new ProductsWithColorVariantsSpec();
        var products = await _productRepository.ListAsync(spec);

        return _mapper.Map<ICollection<Product>, ICollection<ProductDTO>>(products);
    }
}