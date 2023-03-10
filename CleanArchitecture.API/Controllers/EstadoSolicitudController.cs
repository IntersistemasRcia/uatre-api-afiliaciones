using CleanArchitecture.Application.Features.EstadoSolicitud.Queries;
using CleanArchitecture.Application.Features.EstadoSolicitud.Queries.GetEstadosSolicitudesList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers
{
    public class EstadoSolicitudController : BaseApiController
    {
        private readonly IMediator _mediator;

        public EstadoSolicitudController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetEstadosSolicitudesAll")]
        //[Authorize]
        [ProducesResponseType(typeof(IReadOnlyList<EstadoSolicitudVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyCollection<EstadoSolicitudVm>>> GetEstadosSolicitudesAll()
        {
            var query = new GetEstadosSolicitudesListQuery();
            var list = await _mediator.Send(query);

            return Ok(list);
        }
    }
}
