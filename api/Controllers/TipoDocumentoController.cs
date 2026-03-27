using CleanArchitecture.Application.Features.TipoDocumento.Queries;
using CleanArchitecture.Application.Features.TipoDocumento.Queries.GetTiposDocumentosList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers
{
    public class TipoDocumentoController : BaseApiController
    {
        private readonly IMediator _mediator;

        public TipoDocumentoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetTiposDocumentosAll")]
        //[Authorize]
        [ProducesResponseType(typeof(IReadOnlyList<TipoDocumentoVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyCollection<TipoDocumentoVm>>> GetActividadesAll()
        {
            var query = new GetTiposDocumentosListQuery();
            var list = await _mediator.Send(query);

            return Ok(list);
        }
    }
}
