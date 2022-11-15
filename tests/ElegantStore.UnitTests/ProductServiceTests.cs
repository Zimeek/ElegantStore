using ElegantStore.Api.DTOs;
using ElegantStore.Api.Exceptions;
using ElegantStore.Api.Services;
using ElegantStore.Domain.Entities.Aggregates.ProductAggregate;
using ElegantStore.Domain.Interfaces;
using ElegantStore.Domain.Specifications;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace ElegantStore.UnitTests;

public class ProductServiceTests
{
    private readonly ProductService _productService;
    private readonly IRepository<Product> _productRepository = Substitute.For<IRepository<Product>>();

    public ProductServiceTests()
    {
        _productService = new ProductService(_productRepository);
    }

    private Product GetProduct()
    {
        return new Product(3, "Adidas", "Superstars", "blue", "men", "image_base", 10M);
    }

    private List<Product> GetProductList()
    {
        return new List<Product>()
        {
            new Product(1, "Adidas", "Superstar", "blue", "men", "image_base", 20M),
            new Product(2, "Adidas", "Superstar", "blue", "men", "image_base", 20M),
        };
    }

    [Fact]
    public async Task GetProductWithColorVariantsByIdAsync_ShouldReturnProduct_WhenProductExists()
    {
        var product = GetProduct();

        _productRepository.FirstOrDefaultAsync(Arg.Any<ProductWithColorVariantsByIdSpec>()).Returns(product);

        var expectedProduct = await _productService.GetProductWithColorVariantsByIdAsync(product.Id);

        expectedProduct.Should().NotBeNull();
        expectedProduct.Should().BeOfType<ProductFullDTO>();
        expectedProduct.Id.Should().Be(product.Id);
    }

    [Fact]
    public async Task GetProductWithColorVariantsByIdAsync_ShouldThrowException_WhenProductDoesNotExist()
    {
        var productId = 3;

        _productRepository.FirstOrDefaultAsync(Arg.Any<ProductWithColorVariantsByIdSpec>()).ReturnsNull();

        await _productService.Invoking(service => service.GetProductWithColorVariantsByIdAsync(productId)).Should()
            .ThrowAsync<ProductNotFoundException>();
    }

    [Fact]
    public async Task GetProductsPagedAsync_ShouldReturnProducts_WhenProductsExist()
    {
        var products = GetProductList();
        
        _productRepository.ListAsync(Arg.Any<ProductsPagedSpec>()).Returns(products);

        var expectedProducts = await _productService.GetProductsPagedAsync(1, 2, "men");

        expectedProducts.Should().NotBeEmpty();
        expectedProducts.Count.Should().Be(products.Count);

    }
}