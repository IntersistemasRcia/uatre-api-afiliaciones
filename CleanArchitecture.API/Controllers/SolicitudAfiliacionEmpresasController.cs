
using CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresas.Commands.Create;
using CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresas.Queries;
using CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresas.Queries.GetSolicitudAfiliacionEmpresasListSpecs;
using CleanArchitecture.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

    }
}
