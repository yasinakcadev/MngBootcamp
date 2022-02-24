using Application.Features.CorporateCustomers.Commands;
using Application.Features.CorporateCustomers.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorporateCustomersController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateCorporateCustomerCommand createCorporateCustomerCommand)
        {
            var result = await Mediator.Send(createCorporateCustomerCommand);
            return Created("", result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var query = new GetCorporateCustomerListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("getcustomerbyuserid")]
        public async Task<IActionResult> GetCustomerByUserId([FromQuery] PageRequest pageRequest)
        {
            var query = new GetCorporateCustomerListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCorporateCustomerCommand deleteCorporateCustomerCommand)
        {
            var result = await Mediator.Send(deleteCorporateCustomerCommand);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCorporateCustomerCommand updateCorporateCustomerCommand)
        {
            var result = await Mediator.Send(updateCorporateCustomerCommand);
            return Ok(result);
        }

    }
}
