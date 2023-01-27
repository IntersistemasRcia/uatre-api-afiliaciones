using CleanArchitecture.Application.Features.Provincia.Queries;
using CleanArchitecture.Application.Features.Provincia.Queries.GetProvinciasList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers
{
    public class ProvinciasController : BaseApiController
    {
        private readonly IMediator _mediator;

        public ProvinciasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetProvinciasAll")]
        //[Authorize]
        [ProducesResponseType(typeof(IReadOnlyList<ProvinciaVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyCollection<ProvinciaVm>>> GetProvinciasAll()
        {
            var query = new GetProvinciasListQuery();
            var list = await _mediator.Send(query);

            return Ok(list);
        }
    }
}

