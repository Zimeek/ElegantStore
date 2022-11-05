using ElegantStore.Api.Requests;
using ElegantStore.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElegantStore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCartByIdAsync()
    {
        return Ok(await _cartService.GetCartAsync());
    }

    [HttpPost]
    public async Task<IActionResult> AddCartItemAsync([FromBody] AddCartItemRequest request)
    {
        return Ok(await _cartService.AddCartItem(request));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCartItemAsync([FromBody] UpdateCartItemRequest request)
    {
        return Ok(await _cartService.UpdateCartItem(request));
    }

    [HttpPut("{itemId:guid}")]
    public async Task<IActionResult> RemoveCartItemAsync(string itemId)
    {
        await _cartService.RemoveCartItem(itemId);

        return NoContent();
    }

    [HttpPut("Clear")]
    public async Task<IActionResult> ClearCartAsync()
    {
        await _cartService.ClearCart();

        return NoContent();
    }
}