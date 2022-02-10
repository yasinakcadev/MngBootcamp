using Application.Features.Damages.Commands;
using Application.Features.Damages.Queries;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DamageController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateDamageCommand createDamageCommand)
        {
            var result = await Mediator.Send(createDamageCommand);
            return Created("", result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteDamageCommand deleteDamageCommand)
        {
            var result = await Mediator.Send(deleteDamageCommand);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateDamageCommand updateDamageCommand)
        {
            var result = await Mediator.Send(updateDamageCommand);
            return Ok(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var query = new GetDamageListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
           
        }
    }
}
