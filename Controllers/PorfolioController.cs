using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioAPI_V2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PorfolioController : ControllerBase
    {
        [HttpGet("GetHobbies")]
        public IActionResult Hobbies()
        {
            return Ok();
        }

        [HttpGet("GetExperience")]
        public IActionResult Experience()
        {
            return Ok();
        }

        [HttpGet("GetEducation")]
        public IActionResult Education()
        {
            return Ok();
        }

        [HttpGet("GetProjects")]
        public IActionResult Projects()
        {
            return Ok();
        }
    }
}
