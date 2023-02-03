using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Features.Afiliado.Queries.GetAfiliadoList;
using CleanArchitecture.Application.Features.Afiliado.Queries;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using CleanArchitecture.Application.Features.Afiliado.Commands.CreateAfiliado;

namespace CleanArchitecture.API.Controllers
{
    public class AfiliadoController : BaseApiController
    {
        private readonly IMediator _mediator;

        public AfiliadoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAfiliadosAll")]
        //[Authorize]
        [ProducesResponseType(typeof(Pagination<AfiliadoVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Pagination<AfiliadoVm>>> GetAfiliadosAll([FromQuery] GetAfiliadoListQuery query)
        {
            //var query = new GetPadronListQuery(parameters);
            var padrones = await _mediator.Send(query);

            return Ok(padrones);
        }

        [HttpPost(Name = "CreateAfiliado")]
        //[Authorize(Roles = "Administrator")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<int>> CreateDirector([FromBody] CreateAfiliadoCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
