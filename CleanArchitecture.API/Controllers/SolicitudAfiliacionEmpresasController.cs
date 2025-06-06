
using CleanArchitecture.Application.Features.SeccionalLocalidad.Queries.GetSeccionalLocalidadBySeccionalId;
using CleanArchitecture.Application.Features.SeccionalLocalidad.Queries;
using CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresas.Commands.Create;
using CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresas.Queries;
using CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresas.Queries.GetSolicitudAfiliacionEmpresasListSpecs;
using CleanArchitecture.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresasDetalle.Queries;
using CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresasDetalle.Queries.GetByEmpresaId;
using CleanArchitecture.Application.Features.RefLocalidad.Queries.GetRefLocalidadPaginationSpecs;
using CleanArchitecture.Application.Features.RefLocalidad.Queries;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresasDetalle.Queries.GetByEmpresaIdPaginationSpecs;
using CleanArchitecture.Application.Features.Afiliado.Commands.ResolverSolicitudAfiliado;
using CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresas.Commands.ResolverSolicitud;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.API.Controllers
{
    public class SolicitudAfiliacionEmpresasController : BaseApiController
    {
        private readonly IMediator _mediator;

        public SolicitudAfiliacionEmpresasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("GetSolicitudAfiliacionEmpresasSpecs", Name = "GetSolicitudAfiliacionEmpresasSpecs")]
        //[Authorize]
        [ProducesResponseType(typeof(IReadOnlyList<SolicitudAfiliacionEmpresasVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyCollection<SolicitudAfiliacionEmpresasVm>>> GetSolicitudAfiliacionEmpresasSpecs([FromBody] GetSolicitudAfiliacionEmpresasListSpecsQuery query)
        {
            var list = await _mediator.Send(query);

            return Ok(list);
        }

        [HttpPost]
        [ProducesResponseType(typeof(SolicitudAfiliacionEmpresasVm), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateSolicitudAfiliacionEmpresasVm>> Post([FromBody] CreateSolicitudAfiliacionEmpresasCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("GetaDetallesBySolicitudId", Name = "GetaDetallesBySolicitudId")]
        //[Authorize]
        [ProducesResponseType(typeof(IReadOnlyCollection<SolicitudAfiliacionEmpresasDetalleVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyCollection<SolicitudAfiliacionEmpresasDetalleVm>>> GetaDetallesBySolicitudId([FromQuery] GetByEmpresaIdCommand query)
        {
            var data = await _mediator.Send(query);

            return Ok(data);
        }

        [HttpPatch("PatchSolicitud/{solicitudId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<int>> PatchAfiliado(int solicitudId, [FromBody] PatchSolicitudEstadoDto dto)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Error");
            }

            var command = new PatchSolicitudEstadoCommand(solicitudId, dto);
            return await _mediator.Send(command);
        }

        [HttpGet("GetaDetallesBySolicitudIdPaginationSpecs")]
        //[Authorize]
        [ProducesResponseType(typeof(Pagination<SolicitudAfiliacionEmpresasDetalleVm>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<Pagination<SolicitudAfiliacionEmpresasDetalleVm>>> GetaDetallesBySolicitudIdPaginationSpecs([FromQuery] GetByEmpresaIdPaginationSpecsQuery query)
        {
            var list = await _mediator.Send(query);

            return Ok(list);
        }

    }
}
