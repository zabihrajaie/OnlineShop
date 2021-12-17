using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using OnlineShop.Domain.Dtos.Product;
using OnlineShop.Domain.Services;

namespace OnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ProductsFilterDto dto)
        {
            return Ok(await _productService.GetAll(dto));
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductAddDto dto)
        {
            await _productService.AddAsync(dto);
            return Created(nameof(Post), dto);
        }
    }
}
