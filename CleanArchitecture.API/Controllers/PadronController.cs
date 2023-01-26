using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using CleanArchitecture.Application.Features.Padron.Queries;
using CleanArchitecture.Application.Features.Padron.Queries.GetPadronList;
using CleanArchitecture.Application.Models;

namespace CleanArchitecture.API.Controllers
{
    public class PadronController : BaseApiController
    {
        private readonly IMediator _mediator;

        public PadronController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetPadronAll")]
        //[Authorize]
        [ProducesResponseType(typeof(Pagination<PadronVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Pagination<PadronVm>>> GetPadronAll([FromQuery] GetPadronListQuery query)
        {
            //var query = new GetPadronListQuery(parameters);
            var padrones = await _mediator.Send(query);

            return Ok(padrones);
        }
    }
}
