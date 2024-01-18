using CleanArchitecture.Application.Features.RefLocalidad.Command.Create;
using CleanArchitecture.Application.Features.RefLocalidad.Command.DarDeBajaRefLocalidad;
using CleanArchitecture.Application.Features.RefLocalidad.Command.ReactivarRefLocalidad;
using CleanArchitecture.Application.Features.RefLocalidad.Command.Update;
using CleanArchitecture.Application.Features.RefLocalidad.Queries;
using CleanArchitecture.Application.Features.RefLocalidad.Queries.GetRefLocalidadPaginationSpecs;
using CleanArchitecture.Application.Features.RefLocalidad.Queries.GetRefLocalidadSpecs;
using CleanArchitecture.Application.Models;
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

        [HttpGet(Name = "GetRefLocalidadesSpecs")]
        //[Authorize]
        [ProducesResponseType(typeof(IReadOnlyList<RefLocalidadVm>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IReadOnlyList<RefLocalidadVm>>> GetRefLocalidadesSpecs([FromQuery] GetRefLocalidadSpecsQuery query)
        {
            var list = await _mediator.Send(query);

            return Ok(list);
        }

        [HttpGet("GetRefLocalidadesPaginationSpecs")]
        //[Authorize]
        [ProducesResponseType(typeof(Pagination<RefLocalidadVm>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<Pagination<RefLocalidadVm>>> GetRefLocalidadesPaginationSpecs([FromQuery] GetRefLocalidadPaginationSpecsQuery query)
        {
            var list = await _mediator.Send(query);

            return Ok(list);
        }

        [HttpPost]
        [ProducesResponseType(typeof(RefLocalidadVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> Create([FromBody] CreateRefLocalidadCommand request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(typeof(RefLocalidadVm), StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> Update([FromBody] UpdateRefLocalidadCommand request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPatch("DarDeBaja")]
        public async Task<ActionResult<int>> DarDeBaja([FromBody] DarDeBajaRefLocalidadCommand request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPatch("Reactivar")]
        public async Task<ActionResult<int>> Reactivar([FromBody] ReactivarRefLocalidadCommand request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
