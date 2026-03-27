using CleanArchitecture.Application.Features.Afiliado.Queries;
using CleanArchitecture.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using CleanArchitecture.Application.Features.Provincia.Queries.GetNacionalidadesList;

namespace CleanArchitecture.API.Controllers
{
    public class NacionalidadController : BaseApiController
    {
        private readonly IMediator _mediator;

        public NacionalidadController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetNacionalidadesAll")]
        //[Authorize]
        [ProducesResponseType(typeof(Pagination<AfiliadoVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyCollection<NacionalidadVm>>> GetNacionalidadesAll()
        {
            var query = new GetNacionalidadesListQuery();
            var list = await _mediator.Send(query);

            return Ok(list);
        }        
    }
}
