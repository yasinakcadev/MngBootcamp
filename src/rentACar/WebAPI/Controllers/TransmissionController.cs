using Application.Features.Transmissions.Commands;
using Application.Features.Transmissions.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransmissionController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateTransmissionCommand createTransmissionCommand)
        {
            var result = await Mediator.Send(createTransmissionCommand);
            return Created("", result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteTransmissionCommand deleteTransmissionCommand)
        {
            var result = await Mediator.Send(deleteTransmissionCommand);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateTranmissionCommand updateTransmissionCommand)
        {
            var result = await Mediator.Send(updateTransmissionCommand);
            return Ok(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var query = new GetTransmissionListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
