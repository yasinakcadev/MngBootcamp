using Application.Features.Brands.Commands;
using Application.Features.Brands.Queries;
using Application.Features.Cars.Commands;
using Application.Features.Cars.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using static WebAPI.Controllers.BrandController;

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

    }
}
