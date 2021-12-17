using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShop.Domain.Services;

namespace OnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackMethodController : ControllerBase
    {
        private readonly IPackMethodService _packMethodService;
        private readonly ILogger<PackMethodController> _logger;

        public PackMethodController(IPackMethodService packMethodService, ILogger<PackMethodController> logger)
        {
            _packMethodService = packMethodService;
            _logger = logger;
        }

        [HttpGet("GetPack")]
        public IActionResult Index()
        {
            return Ok("PackMethod");
        }
    }
}