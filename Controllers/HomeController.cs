﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OnlineShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Ok");
        }
    }
}
