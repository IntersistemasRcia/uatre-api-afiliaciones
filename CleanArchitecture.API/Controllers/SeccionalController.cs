using CleanArchitecture.Application.Features.Seccional.Command.Create;
using CleanArchitecture.Application.Features.Seccional.Command.DarDeBaja;
using CleanArchitecture.Application.Features.Seccional.Command.Reactivar;
using CleanArchitecture.Application.Features.Seccional.Command.Update;
using CleanArchitecture.Application.Features.Seccional.Queries;
using CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesList;
using CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesListSpecs;
using CleanArchitecture.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.API.Controllers
{
    public class SeccionalController : BaseApiController
    {
        private readonly IMediator _mediator;

        public SeccionalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetSeccionalesAll")]
        //[Authorize]
        [ProducesResponseType(typeof(IReadOnlyList<SeccionalVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyCollection<SeccionalVm>>> GetSeccionalesAll([FromQuery] GetSeccionalesListQuery request)
        {
            var list = await _mediator.Send(request);

            return Ok(list);
        }

        [HttpPost("GetSeccionalesSpecs", Name = "GetSeccionalesSpecs")]
        //[Authorize]
        [ProducesResponseType(typeof(IReadOnlyList<SeccionalVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyCollection<SeccionalVm>>> GetSeccionalesSpecs([FromBody] GetSeccionalesListSpecsQuery query)
        {
            var list = await _mediator.Send(query);

            return Ok(list);
        }

        [HttpPost]
        [ProducesResponseType(typeof(SeccionalVm), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateSeccionalVm>> Post([FromBody] CreateSeccionalCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> Update([FromBody] UpdateSeccionalCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPatch("DarDeBaja")]
        public async Task<ActionResult<int>> DarDeBaja([FromBody] DarDeBajaCommand request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPatch("Reactivar")]
        public async Task<ActionResult<int>> Reactivar([FromBody] ReactivarCommand request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
