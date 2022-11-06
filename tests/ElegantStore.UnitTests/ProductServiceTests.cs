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
    private readonly Mock<IRepository<Product>> _productRepositoryMock = new();

    public ProductServiceTests()
    {
        _productService = new ProductService(_productRepositoryMock.Object);
    }

    private Product GetMockProduct()
    {
        return new Product(3, "Adidas", "Superstars", "blue", "image_base", 10M);
    }

    private List<Product> GetMockProductList()
    {
        return new List<Product>()
        {
            new Product(1, "Adidas", "Superstar", "blue", "image_base", 20M),
            new Product(2, "Adidas", "Superstar", "blue", "image_base", 20M),
        };
    }

    [Fact]
    public async Task GetProductWithColorVariantsByIdAsync_ShouldReturnProduct_WhenProductExists()
    {
        var productMock = GetMockProduct();

        _productRepositoryMock.Setup(repository => repository.FirstOrDefaultAsync(It.IsAny<ProductWithColorVariantsByIdSpec>(), default))
            .ReturnsAsync(productMock);

        var productExpected = await _productService.GetProductWithColorVariantsByIdAsync(productMock.Id);
        
        Assert.NotNull(productExpected);
        Assert.IsType<ProductFullDTO>(productExpected);
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

    [Fact]
    public async Task GetProductsPagedAsync_ShouldReturnProducts_WhenProductsExist()
    {
        var mockProducts = GetMockProductList();

        _productRepositoryMock.Setup(repository => repository.ListAsync(It.IsAny<ProductsPagedSpec>(), default))
            .ReturnsAsync(mockProducts);

        var expectedProducts = await _productService.GetProductsPagedAsync(1, 2);
        
        Assert.NotEmpty(expectedProducts);

    }
}