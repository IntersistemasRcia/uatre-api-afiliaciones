using CleanArchitecture.Application.Features.RefLocalidad.Command.Create;
using CleanArchitecture.Application.Features.RefLocalidad.Command.Update;
using CleanArchitecture.Application.Features.RefLocalidad.Queries;
using CleanArchitecture.Application.Features.RefLocalidad.Queries.GetRefLocalidadSpecs;
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
        public async Task<ActionResult<IReadOnlyCollection<RefLocalidadVm>>> GetRefLocalidadesSpecs([FromQuery] GetRefLocalidadSpecsQuery query)
        {
            var list = await _mediator.Send(query);

            return Ok(list);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> Create([FromBody] CreateRefLocalidadCommand request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> Update([FromBody] UpdateRefLocalidadCommand request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
