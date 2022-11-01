using AutoMapper;
using ElegantStore.Api.Services;
using ElegantStore.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace ElegantStore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductController(
        IProductService productService, 
        IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }
    
    [HttpGet("All")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _productService.GetAllProductsAsync());
    }
}