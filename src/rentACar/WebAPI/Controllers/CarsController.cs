using Application.Features.Cars.Commands;
using Application.Features.Cars.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateCarCommand createCarCommand)
        {
            var result = await Mediator.Send(createCarCommand);
            return Created("", result);
        }

        [HttpPut("rent")]
        public async Task<IActionResult> Rent([FromBody] RentalCarCommand rentalCarCommand)
        {
            var result = await Mediator.Send(rentalCarCommand);
            return Ok(result);
        }

        [HttpPut("redeliver")]
        public async Task<IActionResult> Redeliver([FromBody] RedeliverCarCommand redeliverCarCommand)
        {
            var result = await Mediator.Send(redeliverCarCommand);
            return Ok(result);
        }

        [HttpPut("maintenance")]
        public async Task<IActionResult> Maintenance([FromBody] MaintenanceCarCommand maintenanceCarCommand)
        {
            var result = await Mediator.Send(maintenanceCarCommand);
            return Ok(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var query = new GetCarListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("getbycity")]
        public async Task<IActionResult> GetCarByCity([FromQuery] GetCarListByCityQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
