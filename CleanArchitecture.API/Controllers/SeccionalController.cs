using CleanArchitecture.Application.Features.Seccional.Command.Create;
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
        public async Task<ActionResult<IReadOnlyCollection<SeccionalVm>>> GetSeccionalesAll()
        {
            var query = new GetSeccionalesListQuery();
            var list = await _mediator.Send(query);

            return Ok(list);
        }

        [HttpGet("GetSeccionalesSpecs", Name = "GetSeccionalesSpecs")]
        //[Authorize]
        [ProducesResponseType(typeof(IReadOnlyList<SeccionalVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyCollection<SeccionalVm>>> GetSeccionalesSpecs([FromQuery] GetSeccionalesListSpecsQuery query)
        {
            var list = await _mediator.Send(query);

            return Ok(list);
        }

        [HttpPost]
        [ProducesResponseType(typeof(SeccionalVm), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateSeccionalVm>> Post([FromBody] CreateSeccionalCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
