using CleanArchitecture.Application.Features.DDJJUatre.Queries;
using CleanArchitecture.Application.Features.DDJJUatre.Queries.GetDDJJUatreByCUIL;
using CleanArchitecture.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers
{
    public class DDJJUatreController : BaseApiController
    {
        IMediator _mediator;

        public DDJJUatreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetDDJJUatreListBySpecs", Name = "GetDDJJUatreListBySpecs")]
        //[Authorize]
        [ProducesResponseType(typeof(IReadOnlyList<DDJJUatreVm>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(DDJJUatreVm), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<Pagination<DDJJUatreVm>>> GetDDJJUatreListBySpecs([FromQuery] GetDDJJUatreListBySpecsQuery query)
        {
            var list = await _mediator.Send(query);

            return Ok(list);
        }
    }
}
