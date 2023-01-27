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
        public async Task<ActionResult<IReadOnlyCollection<PuestoVm>>> GetPuestosAll()
        {
            var query = new GetPuestosListQuery();
            var list = await _mediator.Send(query);

            return Ok(list);
        }
    }
}
