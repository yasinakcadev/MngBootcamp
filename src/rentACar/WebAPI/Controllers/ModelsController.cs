using Application.Features.Models.Commands;
using Application.Features.Models.Dtos;
using Application.Features.Models.Queries;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateModelCommand createModelCommand)
        {
            var result = await Mediator.Send(createModelCommand);
            return Created("", result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var query = new GetModelListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getallmodeldetails")]
        public async Task<IActionResult> GetAllModelDetails([FromQuery] PageRequest pageRequest)
        {
            var query = new GetModelDetailListQuery();
            query.PageRequest = pageRequest;

            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getModelDetailListByBrandId")]
        public async Task<IActionResult> GetModelDetailListByBrandId([FromQuery] PageRequest pageRequest, int brandId)
        {
            var query = new GetModelDetailListByBrandIdQuery();
            query.PageRequest = pageRequest;
            query.BrandId = brandId;

            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getallbybrandid")]
        public async Task<IActionResult> GetAllByBrandId([FromQuery] PageRequest pageRequest, int brandId)
        {
            var query = new GetModelByBrandIdQuery();
            query.PageRequest = pageRequest;
            query.BrandId = brandId;
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateModelCommand uptadeModelCommand)
        {
            var result = await Mediator.Send(uptadeModelCommand);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteModelCommand deleteModelCommand)
        {
            var result = await Mediator.Send(deleteModelCommand);
            return Ok(result);
        }

    }
}
