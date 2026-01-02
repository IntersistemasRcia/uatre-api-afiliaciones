using CleanArchitecture.Application.Features.Puesto.Queries;
using CleanArchitecture.Application.Features.Puesto.Queries.GetPuestosList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers
{
    public class PuestoController : BaseApiController
    {
        private readonly IMediator _mediator;

        public PuestoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetPuestosAll")]
        //[Authorize]
        [ProducesResponseType(typeof(IReadOnlyList<PuestoVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyCollection<PuestoVm>>> GetPuestosAll([FromQuery] GetPuestosListQuery request)
        {
            var list = await _mediator.Send(request);

            return Ok(list);
        }
    }
}
