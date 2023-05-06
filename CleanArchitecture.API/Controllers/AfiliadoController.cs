using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Features.Afiliado.Queries.GetAfiliadoList;
using CleanArchitecture.Application.Features.Afiliado.Queries;
using CleanArchitecture.Application.Features.Afiliado.Commands.CreateAfiliado;
using CleanArchitecture.Application.Features.Afiliado.Queries.GetAfiliadoByCUIL;
using CleanArchitecture.Application.Features.Afiliado.Commands.ResolverSolicitudAfiliado;
using CleanArchitecture.Common.Exceptions;
using CleanArchitecture.Application.Features.Afiliado.Commands.UpdateAfiliado;

namespace CleanArchitecture.API.Controllers
{
    public class AfiliadoController : BaseApiController
    {
        private readonly IMediator _mediator;

        public AfiliadoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAfiliadosWithSpec", Name = "GetAfiliadosAll")]
        //[Authorize]
        [ProducesResponseType(typeof(Pagination<AfiliadoVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Pagination<AfiliadoVm>>> GetAfiliadosWithSpec([FromQuery] GetAfiliadoListQuery query)
        {
            //var query = new GetPadronListQuery(parameters);
            var padrones = await _mediator.Send(query);

            return Ok(padrones);
        }

        [HttpGet("GetAfiliadoByCUIL", Name = "GetAfiliado")]
        //[Authorize]
        [ProducesResponseType(typeof(AfiliadoVm), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(AfiliadoVm), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<AfiliadoVm>> GetAfiliado([FromQuery] GetAfiliadoByCUILQuery query)
        {
            //var query = new GetPadronListQuery(parameters);
            var padrones = await _mediator.Send(query);

            return Ok(padrones);
        }

        [HttpPost(Name = "CreateAfiliado")]
        //[Authorize(Roles = "Administrator")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<int>> CreateAfiliado([FromBody] CreateAfiliadoCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPatch(Name = "PatchAfiliado")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<int>> PatchAfiliado([FromRoute] PatchAfiliadoCommand command)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException("Error");
            }

            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateAfiliado")]
        //[Authorize(Roles = "Administrator")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<int>> UpdateAfiliado([FromBody] UpdateAfiliadoCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
