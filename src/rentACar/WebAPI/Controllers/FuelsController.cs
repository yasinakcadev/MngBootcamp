using Application.Features.Fuel.Commands;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static WebAPI.Controllers.BrandController;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelsController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateFuelCommand createFuelCommand)
        {
            var result = await Mediator.Send(createFuelCommand);
            return Created("", result);
        }
    }
}
