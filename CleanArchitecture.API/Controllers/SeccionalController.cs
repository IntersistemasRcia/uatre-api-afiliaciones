using CleanArchitecture.Application.Features.Seccional.Queries;
using CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesByCPList;
using CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.API.Controllers
{
    public class SeccionalController : BaseApiController
    {
        private readonly IMediator _mediator;

        public SeccionalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetSeccionalesAll")]
        //[Authorize]
        [ProducesResponseType(typeof(IReadOnlyList<SeccionalVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyCollection<SeccionalVm>>> GetSeccionalesAll()
        {
            var query = new GetSeccionalesListQuery();
            var list = await _mediator.Send(query);

            return Ok(list);
        }

        [HttpGet("GetSeccionalesByCP", Name = "GetSeccionalesByCP")]
        //[Authorize]
        [ProducesResponseType(typeof(IReadOnlyList<SeccionalVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyCollection<SeccionalVm>>> GetSeccionalesByCP([FromQuery] GetSeccionalesByCPListQuery query)
        {
            var list = await _mediator.Send(query);

            return Ok(list);
        }

        //// GET api/<SeccionalController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<SeccionalController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<SeccionalController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<SeccionalController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
