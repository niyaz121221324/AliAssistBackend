using AliAssistApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace AliAssistApp.Controllers;

public class ProductController : BaseApiController
{
    private readonly IAmazonProductService _amazonProductService; 
    private readonly IAliExpressProductService _aliExpressProductService;

    public ProductController(
        IAmazonProductService amazonProductService, 
        IAliExpressProductService aliExpressProductService)
    {
        _amazonProductService = amazonProductService;
        _aliExpressProductService = aliExpressProductService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string search = "")
    {
        var aliExpressProducts = await _aliExpressProductService.GetProducts(search);
        var amazonProduct = await _amazonProductService.GetProducts(search);
        
        return Ok(aliExpressProducts.Concat(amazonProduct));
    }
}