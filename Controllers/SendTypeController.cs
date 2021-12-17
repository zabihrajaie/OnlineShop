using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        [HttpGet("Index")]
        public IActionResult Index()
        {
            return Ok("SendType");
        }
    }
}