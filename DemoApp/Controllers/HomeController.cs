using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Controllers
{
    [ApiController]
    [Route("api/Home")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Index()
        {
            return "Hello World";
        }
    }
}
