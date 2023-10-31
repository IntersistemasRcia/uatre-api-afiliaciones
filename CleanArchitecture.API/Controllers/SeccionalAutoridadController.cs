using CleanArchitecture.Application.Features.SeccionalAutoridad.Command.CreateSeccionalAutoridad;
using CleanArchitecture.Application.Features.SeccionalAutoridad.Command.DarDeBajaSeccionalAutoridad;
using CleanArchitecture.Application.Features.SeccionalAutoridad.Command.ReactivarSeccionalAutoridad;
using CleanArchitecture.Application.Features.SeccionalAutoridad.Queries;
using CleanArchitecture.Application.Features.SeccionalAutoridad.Queries.GetById;
using CleanArchitecture.Application.Features.SeccionalAutoridad.Queries.GetBySeccional;
using CleanArchitecture.Application.Features.SeccionalAutoridad.Queries.GetBySpecs;
using CleanArchitecture.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers
{    
    public class SeccionalAutoridadController : BaseApiController
    {
        private readonly IMediator _mediator;

        public SeccionalAutoridadController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetSeccionalAutoridadBySpecs", Name = "GetSeccionalAutoridadBySpecs")]
        //[Authorize]
        [ProducesResponseType(typeof(List<SeccionalAutoridadResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<SeccionalAutoridadResponse>>> GetSeccionalAutoridadBySpecs([FromQuery] GetSeccionalAutoridadBySpecsQuery query)
        {
            var list = await _mediator.Send(query);

            return Ok(list);
        }

        [HttpGet("GetSeccionalAutoridadById", Name = "GetSeccionalAutoridadById")]
        //[Authorize]
        [ProducesResponseType(typeof(SeccionalAutoridadResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(SeccionalAutoridadResponse), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<SeccionalAutoridadResponse>> GetSeccionalAutoridadById([FromQuery] GetSeccionalAutoridadByIdQuery query)
        {
            //var query = new GetPadronListQuery(parameters);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("GetSeccionalAutoridadBySeccional", Name = "GetSeccionalAutoridadBySeccional")]
        //[Authorize]
        [ProducesResponseType(typeof(IReadOnlyCollection<SeccionalAutoridadResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IReadOnlyCollection<SeccionalAutoridadResponse>), (int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<SeccionalAutoridadResponse>> GetSeccionalAutoridadBySeccional([FromQuery] GetSeccionalAutoridadesBySeccionalQuery query)
        {
            //var query = new GetPadronListQuery(parameters);
            var list = await _mediator.Send(query);
            if (!list.Any())
            {
                return NotFound();
            }

            return Ok(list);
        }

        [HttpPost(Name = "CreateSeccionalAutoridad")]
        //[Authorize(Roles = "Administrator")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<int>> CreateSeccionalAutoridad([FromBody] CreateSeccionalAutoridadCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPatch("DarDeBaja")]
        public async Task<ActionResult<int>> DarDeBaja([FromBody] DarDeBajaSeccionalAutoridadCommand request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPatch("Reactivar")]
        public async Task<ActionResult<int>> Reactivar([FromBody] ReactivarDarDeBajaSeccionalAutoridadCommand request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
