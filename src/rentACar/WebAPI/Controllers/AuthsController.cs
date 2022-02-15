using Application.Features.Users.Commands;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : BaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand registerUserCommand)
        {
            var result = await Mediator.Send(registerUserCommand);
            return Created("", result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand loginUserCommand)
        {
            var result = await Mediator.Send(loginUserCommand);
            return Ok(result);
        }
    }
}
