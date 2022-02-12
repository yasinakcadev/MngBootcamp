using Application.Features.AdditionalServices.Commands;
using Application.Features.AdditionalServices.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdditionalServicesController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateAdditionalServiceCommand createAdditionalService)
        {
            var result = await Mediator.Send(createAdditionalService);
            return Created("", result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var query = new GetAdditionalServicesQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);

        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateAdditionalServiceCommand updateAdditionalServiceCommand)
        {
            var result = await Mediator.Send(updateAdditionalServiceCommand);
            return Ok(result);
        }
    }
}
