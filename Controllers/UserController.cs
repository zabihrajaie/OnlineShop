using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using OnlineShop.Domain.Dtos.User;
using OnlineShop.Domain.Services;

namespace OnlineShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] UsersFilterDto dto)
        {
            return Ok(await _userService.GetAll(dto));
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserAddDto dto)
        {
            await _userService.AddAsync(dto);
            return Created(nameof(Post), dto);
        }
    }
}
