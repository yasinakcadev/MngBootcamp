using Application.Features.Cities.Commands;
using Application.Features.Cities.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateCityCommand createCityCommand)
        {
            var result = await Mediator.Send(createCityCommand);
            return Created("", result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var query = new GetCityListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCityCommand deleteCityCommand)
        {
            var result = await Mediator.Send(deleteCityCommand);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCityCommand updateCityCommand)
        {
            var result = await Mediator.Send(updateCityCommand);
            return Ok(result);
        }
    }
}
