using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShop.Domain.Dtos.PackMethod;
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

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]PackMethodsFilterDto dto)
        {
            return Ok(await _packMethodService.GetAll(dto));
        }

        [HttpPost]
        public async Task<IActionResult> Post(PackMethodAddDto dto)
        {
            await _packMethodService.AddAsync(dto);
            return Created(nameof(Post), dto);
        }
    }
}