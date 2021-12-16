using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShop.Domain.Services;

namespace OnlineShop.Controllers
{
    public class PackMethodController : BaseController
    {
        private readonly IPackMethodService _packMethodService;
        private readonly ILogger<PackMethodController> _logger;

        public PackMethodController(IPackMethodService packMethodService, ILogger<PackMethodController> logger)
        {
            _packMethodService = packMethodService;
            _logger = logger;
        }

        // GET
        public IActionResult Index()
        {
            return Ok("PackMethod");
        }
    }
}