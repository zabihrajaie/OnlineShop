using Microsoft.AspNetCore.Mvc;
using OnlineShop.Domain.Services;

namespace OnlineShop.Controllers
{
    public class SendTypeController : BaseController
    {
        private readonly ISendTypeService _sendTypeService;

        public SendTypeController(ISendTypeService sendTypeService)
        {
            _sendTypeService = sendTypeService;
        }

        // GET
        public IActionResult Index()
        {
            return Ok();
        }
    }
}