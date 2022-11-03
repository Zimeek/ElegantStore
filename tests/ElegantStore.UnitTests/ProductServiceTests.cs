using AutoMapper;
using ElegantStore.Api.DTOs;
using ElegantStore.Api.Exceptions;
using ElegantStore.Api.Services;
using ElegantStore.Domain.Entities.Aggregates.ProductAggregate;
using ElegantStore.Domain.Interfaces;
using ElegantStore.Domain.Specifications;
using Moq;

namespace ElegantStore.UnitTests;

public class ProductServiceTests
{
    private readonly ProductService _productService;
    private readonly Mock<IRepository<Product>> _productRepositoryMock = new Mock<IRepository<Product>>();
    private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
    
    public ProductServiceTests()
    {
        _productService = new ProductService(_productRepositoryMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task GetProductWithColorVariantsByIdAsync_ShouldReturnProduct_WhenProductExists()
    {
        var productMock = new Product(3, "Adidas", "Superstars", "blue", "image_base", 10M);
        
        var productDtoMock = new ProductFullDTO()
        {
            Id = productMock.Id,
            Brand = productMock.Brand,
            Model = productMock.Model,
            Color = productMock.Color,
            ImageBase = productMock.ImageBase,
            Price = productMock.Price,
            ColorVariants = new List<ProductColorDTO>()
        };

        _mapperMock.Setup(mapper => mapper.Map<Product, ProductFullDTO>(It.IsAny<Product>()))
            .Returns(productDtoMock);

        _productRepositoryMock.Setup(repository => repository.FirstOrDefaultAsync(It.IsAny<ProductWithColorVariantsByIdSpec>(), default))
            .ReturnsAsync(productMock);

        var productExpected = await _productService.GetProductWithColorVariantsByIdAsync(productMock.Id);
        
        Assert.Equal(productMock.Id, productExpected.Id);
    }

    [Fact]
    public async Task GetProductWithColorVariantsByIdAsync_ShouldThrowException_WhenProductDoesNotExist()
    {
        var productId = 3;

        _productRepositoryMock.Setup(repository =>
                repository.FirstOrDefaultAsync(It.IsAny<ProductWithColorVariantsByIdSpec>(), default))
            .ReturnsAsync(() => null);

        await Assert.ThrowsAsync<ProductNotFoundException>(() => _productService.GetProductWithColorVariantsByIdAsync(productId));
    }
}