using AutoMapper;
using ElegantStore.Api.DTOs;
using ElegantStore.Api.Exceptions;
using ElegantStore.Api.Requests;
using ElegantStore.Api.Services;
using ElegantStore.Domain.Entities.Aggregates.CartAggregate;
using ElegantStore.Domain.Interfaces;
using ElegantStore.Domain.Specifications;
using Microsoft.AspNetCore.Http;
using Moq;

namespace ElegantStore.UnitTests;

public class CartServiceTests
{
    private readonly CartService _cartService;
    private readonly Mock<IRepository<Cart>> _cartRepositoryMock = new ();
    private readonly Mock<IMapper> _mapperMock = new();
    private readonly Mock<IHttpContextAccessor> _httpContextAccessorMock = new ();

    public CartServiceTests()
    {
        _cartService = new CartService(_cartRepositoryMock.Object, _mapperMock.Object, _httpContextAccessorMock.Object);
    }

    private Cart GetEmptyMockCart()
    {
        return new Cart()
        {
            Id = Guid.NewGuid().ToString()
        };
    }

    private Cart GetMockCart()
    {
        var cart = new Cart()
        {
            Id = Guid.NewGuid().ToString()
        };
        
        var item = new CartItem(cart.Id, 1, 1);
        item.Id = "6c77c52c-c94d-4c3d-87bd-31e6b919dda2";
        
        cart.Items.Add(item);

        return cart;
    }

    private CartDTO GetEmptyCartDto(Cart mockCart)
    {
        return new CartDTO()
        {
            Id = mockCart.Id,
            Items = new List<CartItemDTO>()
        };
    }

    private CartItemDTO GetMockCartItemDto()
    {
        return new CartItemDTO()
        {
            Id ="6c77c52c-c94d-4c3d-87bd-31e6b919dda2",
            ProductId = 1,
            Quantity = 1
        };
    }

    private AddCartItemRequest GetMockAddCartItemRequest()
    {
        return new AddCartItemRequest()
        {
            ProductId = 1,
            Quantity = 1
        };
    }

    private UpdateCartItemRequest GetMockUpdateCartItemRequest()
    {
        return new UpdateCartItemRequest()
        {
            ItemId = "6c77c52c-c94d-4c3d-87bd-31e6b919dda2",
            Quantity = 1
        };
    }

    private void SetupIHttpContextAccessor(string cartId)
    {
        _httpContextAccessorMock.Setup(context => context.HttpContext!.Request.Headers.Add("cartId", cartId));
    }

    [Fact]
    public async Task GetCartAsync_CreateAndReturnCart_WhenCartDoesNotExist()
    {
        var mockCart = GetEmptyMockCart();
        var mockCartDto = GetEmptyCartDto(mockCart);

        SetupIHttpContextAccessor(Guid.NewGuid().ToString());

        _cartRepositoryMock.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<CartByIdSpec>(), default))
            .ReturnsAsync(() => null);

        _cartRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Cart>(), default))
            .ReturnsAsync(mockCart);

        _mapperMock.Setup(mapper => mapper.Map<Cart, CartDTO>(It.IsAny<Cart>()))
            .Returns(mockCartDto);

        var expectedCart = await _cartService.GetCartAsync();

        Assert.NotNull(expectedCart);
        Assert.IsType<CartDTO>(expectedCart);
        Assert.Equal(mockCart.Id, expectedCart.Id);
    }

    [Fact]
    public async Task GetCartAsync_ReturnCart_WhenCartExists()
    {
        var mockCart = GetEmptyMockCart();
        var mockCartDto = GetEmptyCartDto(mockCart);

        SetupIHttpContextAccessor(mockCart.Id);

        _cartRepositoryMock.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<CartByIdSpec>(), default))
            .ReturnsAsync(mockCart);

        _mapperMock.Setup(mapper => mapper.Map<Cart, CartDTO>(It.IsAny<Cart>()))
            .Returns(mockCartDto);

        var expectedCart = await _cartService.GetCartAsync();

        Assert.NotNull(expectedCart);
        Assert.IsType<CartDTO>(expectedCart);
        Assert.Equal(mockCart.Id, expectedCart.Id);
    }

    [Fact]
    public async Task AddCartItem_ShouldAddItem_WhenItemNotInCart()
    {
        var mockCart = GetEmptyMockCart();
        var mockRequest = GetMockAddCartItemRequest();
        var mockCartItemDto = GetMockCartItemDto();
        
        SetupIHttpContextAccessor(mockCart.Id);
        
        _cartRepositoryMock.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<CartByIdSpec>(), default))
            .ReturnsAsync(mockCart);

        _mapperMock.Setup(mapper => mapper.Map<CartItem, CartItemDTO>(It.IsAny<CartItem>()))
            .Returns(mockCartItemDto);

        var expectedItem = await _cartService.AddCartItem(mockRequest);
        
        Assert.NotNull(expectedItem);
        Assert.IsType<CartItemDTO>(expectedItem);
        Assert.Equal(mockRequest.ProductId, expectedItem.ProductId);
    }

    [Fact]
    public async Task AddCartItem_ShouldThrowException_WhenItemAlreadyInCart()
    {
        var mockCart = GetMockCart();
        var mockRequest = GetMockAddCartItemRequest();
        
        SetupIHttpContextAccessor(mockCart.Id);
        
        _cartRepositoryMock.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<CartByIdSpec>(), default))
            .ReturnsAsync(mockCart);

        await Assert.ThrowsAsync<ProductAlreadyInCartException>(() => _cartService.AddCartItem(mockRequest));
    }

    [Fact]
    public async Task UpdateCartItem_ShouldUpdateItem_WhenItemExists()
    {
        var mockCart = GetMockCart();
        var mockRequest = GetMockUpdateCartItemRequest();
        var mockCartItemDto = GetMockCartItemDto();
        
        SetupIHttpContextAccessor(mockCart.Id);
        
        _cartRepositoryMock.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<CartByIdSpec>(), default))
            .ReturnsAsync(mockCart);
        
        _mapperMock.Setup(mapper => mapper.Map<CartItem, CartItemDTO>(It.IsAny<CartItem>()))
            .Returns(mockCartItemDto);

        var expectedItem = await _cartService.UpdateCartItem(mockRequest);
        
        Assert.NotNull(expectedItem);
        Assert.IsType<CartItemDTO>(expectedItem);
        Assert.Equal(mockRequest.ItemId, expectedItem.Id);
        Assert.Equal(mockRequest.Quantity, expectedItem.Quantity);
    }

    [Fact]
    public async Task UpdateCartItem_ShouldThrowException_WhenItemDoesNotExist()
    {
        var mockCart = GetEmptyMockCart();
        var mockRequest = GetMockUpdateCartItemRequest();
        
        SetupIHttpContextAccessor(mockCart.Id);
        
        _cartRepositoryMock.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<CartByIdSpec>(), default))
            .ReturnsAsync(mockCart);

        await Assert.ThrowsAsync<CartItemNotFoundException>(() => _cartService.UpdateCartItem(mockRequest));

    }

    [Fact]
    public async Task RemoveCartItem_ShouldRemoveItem_WhenItemExists()
    {
        var mockCart = GetMockCart();
        var itemId = "6c77c52c-c94d-4c3d-87bd-31e6b919dda2";
        
        SetupIHttpContextAccessor(mockCart.Id);
        
        _cartRepositoryMock.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<CartByIdSpec>(), default))
            .ReturnsAsync(mockCart);

        await _cartService.RemoveCartItem(itemId);
        
        Assert.Empty(mockCart.Items);
    }
    
    [Fact]
    public async Task ClearCart_ShouldRemoveAllItems_WhenItemsExist()
    {
        var mockCart = GetMockCart();

        SetupIHttpContextAccessor(mockCart.Id);
        
        _cartRepositoryMock.Setup(repo => repo.FirstOrDefaultAsync(It.IsAny<CartByIdSpec>(), default))
            .ReturnsAsync(mockCart);

        await _cartService.ClearCart();
        
        Assert.Empty(mockCart.Items);
    }
}