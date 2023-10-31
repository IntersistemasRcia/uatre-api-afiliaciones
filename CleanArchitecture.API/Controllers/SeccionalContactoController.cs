using CleanArchitecture.Application.Features.SeccionalContacto.Command.Create;
using CleanArchitecture.Application.Features.SeccionalContacto.Command.DarDeBajaSeccionalContacto;
using CleanArchitecture.Application.Features.SeccionalContacto.Command.ReactivarSeccionalContacto;
using CleanArchitecture.Application.Features.SeccionalContacto.Queries;
using CleanArchitecture.Application.Features.SeccionalContacto.Queries.GetById;
using CleanArchitecture.Application.Features.SeccionalContacto.Queries.GetBySpecs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers
{
    public class SeccionalContactoController : BaseApiController
    {
        private readonly IMediator _mediator;

        public SeccionalContactoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetSeccionalContactoBySpecs", Name = "GetSeccionalContactoBySpecs")]
        //[Authorize]
        [ProducesResponseType(typeof(List<SeccionalContactoResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<SeccionalContactoResponse>>> GetSeccionalContactoBySpecs([FromQuery] GetSeccionalContactoBySpecsQuery query)
        {
            var padrones = await _mediator.Send(query);

            return Ok(padrones);
        }

        [HttpGet("GetSeccionalContactoById", Name = "GetSeccionalContactoById")]
        //[Authorize]
        [ProducesResponseType(typeof(SeccionalContactoResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(SeccionalContactoResponse), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<SeccionalContactoResponse>> GetSeccionalContactoById([FromQuery] GetSeccionalContactoByIdQuery query)
        {
            //var query = new GetPadronListQuery(parameters);
            var padrones = await _mediator.Send(query);

            return Ok(padrones);
        }

        [HttpPost(Name = "CreateSeccionalContacto")]
        //[Authorize(Roles = "Administrator")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<int>> CreateSeccionalContacto([FromBody] CreateSeccionalContactoCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPatch("DarDeBaja")]
        public async Task<ActionResult<int>> DarDeBaja([FromBody] DarDeBajaSeccionalContactoCommand request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPatch("Reactivar")]
        public async Task<ActionResult<int>> Reactivar([FromBody] ReactivarSeccionalContactoCommand request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
