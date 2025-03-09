using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioAPI_V2.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class Authentication : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login()
        {
            return Ok();
        }

        [HttpPost("register")]
        public IActionResult Register()
        {
            return Ok();
        }
    }
}
