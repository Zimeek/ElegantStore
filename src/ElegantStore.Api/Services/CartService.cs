using ElegantStore.Api.DTOs;
using ElegantStore.Api.Exceptions;
using ElegantStore.Api.Requests;
using ElegantStore.Domain.Entities.Aggregates.CartAggregate;
using ElegantStore.Domain.Interfaces;
using ElegantStore.Domain.Specifications;
using Mapster;

namespace ElegantStore.Api.Services;

public class CartService : ICartService
{
    private readonly IRepository<Cart> _cartRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CartService(
        IRepository<Cart> cartRepository,
        IHttpContextAccessor httpContextAccessor)
    {
        _cartRepository = cartRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    private string GetRequestCartId()
    {
        return _httpContextAccessor.HttpContext!.Request.Headers["cartId"].ToString();
    }
    
    private async Task<Cart> GetCart()
    {
        var spec = new CartByIdSpec(GetRequestCartId());
        var cart = await _cartRepository.FirstOrDefaultAsync(spec);

        if (cart is null)
        {
            cart = await _cartRepository.AddAsync(new Cart());
        }
        
        return cart;
    }

    public async Task<CartDTO> GetCartAsync()
    {
        var cart = await GetCart();

        return cart.Adapt<CartDTO>();
    }
    

    public async Task<CartItemDTO> AddCartItem(AddCartItemRequest request)
    {
        var cart = await GetCart();

        var item = cart.AddItem(request.ProductId, request.Quantity);

        if (item is null)
        {
            throw new ProductAlreadyInCartException(request.ProductId);
        }

        await _cartRepository.UpdateAsync(cart);

        return item.Adapt<CartItemDTO>();
    }

    public async Task<CartItemDTO> UpdateCartItem(UpdateCartItemRequest request)
    {
        var cart = await GetCart();
        var item = cart.UpdateItem(request.ItemId, request.Quantity);

        if (item is null)
        {
            throw new CartItemNotFoundException(request.ItemId);
        }

        await _cartRepository.UpdateAsync(cart);

        return item.Adapt<CartItemDTO>();
    }

    public async Task RemoveCartItem(string itemId)
    {
        var cart = await GetCart();
        cart.RemoveItem(itemId);

        await _cartRepository.UpdateAsync(cart);
    }

    public async Task ClearCart()
    {
        var cart = await GetCart();
        cart.Clear();
        
        await _cartRepository.UpdateAsync(cart);
    }
}