using ElegantStore.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElegantStore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(
        IProductService productService)
    {
        _productService = productService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetProductsAsync([FromQuery] int? page, [FromQuery] int? pageSize)
    {
        if (page is not null && pageSize is not null)
        {
            return Ok(await _productService.GetProductsPagedAsync((int)page, (int)pageSize));
        }
        
        return Ok(await _productService.GetProductsAsync());
    }

    [HttpGet("{productId:int}")]
    public async Task<IActionResult> GetProductByIdAsync(int productId)
    {
        return Ok(await _productService.GetProductWithColorVariantsByIdAsync(productId));
    }
}