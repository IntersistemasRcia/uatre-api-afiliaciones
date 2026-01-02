using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using CleanArchitecture.Application.Features.AfiliadoEstadoSolicitud.Queries.GetByAfiliadoId;
using CleanArchitecture.Application.Features.AfiliadoEstadoSolicitud.Queries;

namespace CleanArchitecture.API.Controllers
{
    public class AfiliadoEstadoSolicitudController : BaseApiController
    {
        private readonly IMediator _mediator;

        public AfiliadoEstadoSolicitudController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{AfiliadoId}")]
        //[Authorize]
        [ProducesResponseType(typeof(IReadOnlyList<AfiliadoEstadoSolicitudVm>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IReadOnlyList<AfiliadoEstadoSolicitudVm>), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IReadOnlyCollection<AfiliadoEstadoSolicitudVm>>> GetByAfiliado(int AfiliadoId, [FromQuery] string Sort)
        {
            var query = new GetByAfiliadoIdQuery(AfiliadoId, Sort);
            var list = await _mediator.Send(query);

            return Ok(list);
        }
    }
}
