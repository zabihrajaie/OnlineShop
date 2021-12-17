using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShop.Domain.Dtos.SendType;
using OnlineShop.Domain.Services;

namespace OnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendTypeController : ControllerBase
    {
        private readonly ISendTypeService _sendTypeService;
        private readonly ILogger<SendTypeController> _logger;

        public SendTypeController(ISendTypeService sendTypeService, ILogger<SendTypeController> logger)
        {
            _sendTypeService = sendTypeService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] SendTypesFilterDto dto)
        {
            return Ok(await _sendTypeService.GetAll(dto));
        }

        [HttpPost]
        public async Task<IActionResult> Post(SendTypeAddDto dto)
        {
            await _sendTypeService.AddAsync(dto);
            return Created(nameof(Post), dto);
        }
    }
}