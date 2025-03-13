using Domain.Entities;
using Integrations.CustomExceptions;
using Integrations.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Interfaces.Services;
using Services.ServiceExceptions;

namespace PortfolioAPI_V2.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthenticationController(IAuthService authService) {
             _authService = authService;
        }


        [HttpPost("login")]
        public IActionResult Login(LoginModel loginModel)
        {
            try
            {
                var result = _authService.Login(loginModel);

                return Ok(result);
            }
            catch (DatabaseException DbE)
            {
                return StatusCode(500, DbE.Message);
            }
            catch (NoContentException NoCE)
            {
                return BadRequest(NoCE.Message);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            
            
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDTO user)
        {

            try
            {
                var result = _authService.Register(user);
                if (result)
                {
                    return Ok("User registered successfully");
                }
                return Ok("unknown fail");
            }
            catch (DatabaseException DbE)
            {
                return StatusCode(500, DbE.Message);
            }
            catch (NoContentException NoCE)
            {
                return BadRequest(NoCE.Message);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
