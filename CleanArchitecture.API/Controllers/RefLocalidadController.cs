using CleanArchitecture.Application.Features.RefLocalidad.Queries;
using CleanArchitecture.Application.Features.RefLocalidad.Queries.GetRefLocalidadByProvincia;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers
{
    public class RefLocalidadController :BaseApiController
    {
        private readonly IMediator _mediator;

        public RefLocalidadController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetRefLocalidadesByProvincia")]
        //[Authorize]
        [ProducesResponseType(typeof(IReadOnlyList<RefLocalidadVm>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IReadOnlyCollection<RefLocalidadVm>>> GetRefLocalidadesByProvincia([FromQuery] GetRefLocalidadByProvinciaQuery query)
        {
            var list = await _mediator.Send(query);

            return Ok(list);
        }
    }
}
