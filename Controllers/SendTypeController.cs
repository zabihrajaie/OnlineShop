using Microsoft.AspNetCore.Mvc;
using OnlineShop.Domain.Services;

namespace OnlineShop.Controllers
{
    public class PackMethodController : BaseController
    {
        private readonly IPackMethodService _packMethodService;

        public PackMethodController(IPackMethodService packMethodService)
        {
            _packMethodService = packMethodService;
        }

        // GET
        public IActionResult Index()
        {
            return Ok();
        }
    }
}