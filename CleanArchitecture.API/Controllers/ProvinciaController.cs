using CleanArchitecture.Application.Features.Provincia.Queries.GetProvinciasList;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers
{
    public class ProvinciaController : BaseApiController
    {
        private readonly IMediator _mediator;

        public ProvinciaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetProvinciasAll")]
        //[Authorize]
        [ProducesResponseType(typeof(IReadOnlyList<Provincia>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyCollection<ProvinciaVm>>> GetProvinciasAll()
        {
            var query = new GetProvinciasListQuery();
            var list = await _mediator.Send(query);

            return Ok(list);
        }
    }
}

