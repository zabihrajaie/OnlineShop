using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.Controllers
{
    public class BasicInformationController : BaseController
    {
        public IActionResult Get()
        {
            return Ok("Data");
        }
    }
}
