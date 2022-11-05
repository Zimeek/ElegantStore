using ElegantStore.Api.DTOs;
using ElegantStore.Api.Requests;

namespace ElegantStore.Api.Services;

public interface ICartService
{
    public Task<CartDTO> GetCartAsync();
    public Task<CartItemDTO> AddCartItem(AddCartItemRequest request);
    public Task<CartItemDTO> UpdateCartItem(UpdateCartItemRequest request);
    public Task RemoveCartItem(string itemId);
    public Task ClearCart();
}