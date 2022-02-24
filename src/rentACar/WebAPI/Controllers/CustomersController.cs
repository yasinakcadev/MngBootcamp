using Application.Features.Customers.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController
    {
     

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var query = new GetCustomerListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("getcustomerbyuserid")]
        public async Task<IActionResult> GetCustomerByUserId([FromQuery] GetCustomerByUserIdListQuery query)
        {
           
            var result = await Mediator.Send(query);
            return Ok(result);
        }


    }
}
