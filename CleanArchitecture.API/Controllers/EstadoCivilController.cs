using CleanArchitecture.Application.Features.EstadoCivil.Queries;
using CleanArchitecture.Application.Features.EstadoCivil.Queries.GetEstadoCivilList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers
{
    public class EstadoCivilController : BaseApiController
    {
        IMediator _mediator;

        public EstadoCivilController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetEstadosCivilesAll")]
        //[Authorize]
        [ProducesResponseType(typeof(IReadOnlyList<EstadoCivilVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyCollection<EstadoCivilVm>>> GetEstadosCivilesAll()
        {
            var query = new GetEstadoCivilListQuery();
            var list = await _mediator.Send(query);

            return Ok(list);
        }
    }
}
