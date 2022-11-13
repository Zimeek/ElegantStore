using ElegantStore.Api.DTOs;
using ElegantStore.Api.Exceptions;
using ElegantStore.Api.Requests;
using ElegantStore.Api.Services;
using ElegantStore.Domain.Entities.Aggregates.CartAggregate;
using ElegantStore.Domain.Interfaces;
using ElegantStore.Domain.Specifications;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;

namespace ElegantStore.UnitTests;

public class CartServiceTests
{
    private readonly CartService _cartService;
    private readonly IRepository<Cart> _cartRepository = Substitute.For<IRepository<Cart>>();
    private readonly IHttpContextAccessor _httpContextAccessor = Substitute.For<IHttpContextAccessor>();

    public CartServiceTests()
    {
        _cartService = new CartService(_cartRepository, _httpContextAccessor);
    }

    private Cart GetEmptyCart()
    {
        return new Cart()
        {
            Id = Guid.NewGuid().ToString()
        };
    }

    private Cart GetCart()
    {
        var cart = new Cart()
        {
            Id = Guid.NewGuid().ToString()
        };
        
        var item = new CartItem(cart.Id, 1, 1, "black");
        item.Id = "6c77c52c-c94d-4c3d-87bd-31e6b919dda2";
        
        cart.Items.Add(item);

        return cart;
    }

    private AddCartItemRequest GetAddCartItemRequest()
    {
        return new AddCartItemRequest()
        {
            ProductId = 1,
            Color = "black"
        };
    }

    private UpdateCartItemRequest GetUpdateCartItemRequest()
    {
        return new UpdateCartItemRequest()
        {
            ItemId = "6c77c52c-c94d-4c3d-87bd-31e6b919dda2"
        };
    }

    [Fact]
    public async Task GetCartAsync_CreateCart_WhenCartDoesNotExist()
    {
        var cart = GetEmptyCart();

        _httpContextAccessor.HttpContext!.Request.Headers.Add("cartId",cart.Id);
        
        _cartRepository.FirstOrDefaultAsync(Arg.Any<CartByIdSpec>()).ReturnsNull();
        _cartRepository.AddAsync(Arg.Any<Cart>()).Returns(cart);

        var expectedCart = await _cartService.GetCartAsync();

        expectedCart.Should().NotBeNull();
        expectedCart.Should().BeOfType<CartDTO>();
        expectedCart.Id.Should().Be(cart.Id);
    }

    [Fact]
    public async Task GetCartAsync_ReturnCart_WhenCartExists()
    {
        var cart = GetEmptyCart();

        _httpContextAccessor.HttpContext!.Request.Headers.Add("cartId", cart.Id);

        _cartRepository.FirstOrDefaultAsync(Arg.Any<CartByIdSpec>()).Returns(cart);

        var expectedCart = await _cartService.GetCartAsync();

        expectedCart.Should().NotBeNull();
        expectedCart.Should().BeOfType<CartDTO>();
        expectedCart.Id.Should().Be(cart.Id);
    }

    [Fact]
    public async Task AddCartItem_ShouldAddItem_WhenItemNotInCart()
    {
        var cart = GetEmptyCart();
        var request = GetAddCartItemRequest();

        _httpContextAccessor.HttpContext!.Request.Headers.Add("cartId", cart.Id);
        
        _cartRepository.FirstOrDefaultAsync(Arg.Any<CartByIdSpec>()).Returns(cart);

        var expectedItem = await _cartService.AddCartItem(request);

        expectedItem.Should().NotBeNull();
        expectedItem.Should().BeOfType<CartItemDTO>();
        expectedItem.ProductId.Should().Be(request.ProductId);
    }

    [Fact]
    public async Task AddCartItem_ShouldThrowException_WhenItemAlreadyInCart()
    {
        var cart = GetCart();
        var request = GetAddCartItemRequest();
        
        _httpContextAccessor.HttpContext!.Request.Headers.Add("cartId", cart.Id);
        
        _cartRepository.FirstOrDefaultAsync(Arg.Any<CartByIdSpec>()).Returns(cart);

        await _cartService.Invoking(service => service.AddCartItem(request)).Should()
            .ThrowAsync<ProductAlreadyInCartException>();
    }

    [Fact]
    public async Task UpdateCartItem_ShouldUpdateItem_WhenItemExists()
    {
        var cart = GetCart();
        var request = GetUpdateCartItemRequest();

        _httpContextAccessor.HttpContext!.Request.Headers.Add("cartId", cart.Id);
        
        _cartRepository.FirstOrDefaultAsync(Arg.Any<CartByIdSpec>()).Returns(cart);

        var expectedItem = await _cartService.UpdateCartItem(request);

        expectedItem.Should().NotBeNull();
        expectedItem.Should().BeOfType<CartItemDTO>();
        expectedItem.Id.Should().Be(request.ItemId);
    }

    [Fact]
    public async Task UpdateCartItem_ShouldThrowException_WhenItemDoesNotExist()
    {
        var cart = GetEmptyCart();
        var request = GetUpdateCartItemRequest();
        
        _httpContextAccessor.HttpContext!.Request.Headers.Add("cartId", cart.Id);
        
        _cartRepository.FirstOrDefaultAsync(Arg.Any<CartByIdSpec>()).Returns(cart);

        await _cartService.Invoking(service => service.UpdateCartItem(request)).Should()
            .ThrowAsync<CartItemNotFoundException>();
    }

    [Fact]
    public async Task RemoveCartItem_ShouldRemoveItem_WhenItemExists()
    {
        var cart = GetCart();
        var itemId = "6c77c52c-c94d-4c3d-87bd-31e6b919dda2";
        
        _httpContextAccessor.HttpContext!.Request.Headers.Add("cartId", cart.Id);
        
        _cartRepository.FirstOrDefaultAsync(Arg.Any<CartByIdSpec>()).Returns(cart);

        await _cartService.RemoveCartItem(itemId);

        cart.Items.Should().BeEmpty();
    }
    
    [Fact]
    public async Task ClearCart_ShouldRemoveAllItems_WhenItemsExist()
    {
        var cart = GetCart();

        _httpContextAccessor.HttpContext!.Request.Headers.Add("cartId", cart.Id);
        
        _cartRepository.FirstOrDefaultAsync(Arg.Any<CartByIdSpec>()).Returns(cart);

        await _cartService.ClearCart();
        
        cart.Items.Should().BeEmpty();
    }
}