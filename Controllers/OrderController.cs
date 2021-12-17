using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using OnlineShop.Domain.Dtos.Order;
using OnlineShop.Domain.Services;

namespace OnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] OrdersFilterDto dto)
        {
            return Ok(await _orderService.GetAll(dto));
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderAddDto dto)
        {
            await _orderService.AddAsync(dto);
            return Created(nameof(Post), dto);
        }
    }
}
