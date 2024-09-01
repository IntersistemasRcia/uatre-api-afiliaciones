using CleanArchitecture.API.Errors;
using CleanArchitecture.Application.Features.Afiliado.Queries.GetAfiliadoList;
using CleanArchitecture.Application.Features.Afiliado.Queries;
using CleanArchitecture.Application.Features.AfiliadoFormulariosAfiliacion.Commands.AfiliadoFormulariosAfiliacionCreate;
using CleanArchitecture.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using CleanArchitecture.Application.Features.AfiliadoFormulariosAfiliacion.Queries.GetAfiliadoFormularioAfiliacionList;

namespace CleanArchitecture.API.Controllers;

public class AfiliadoFormulariosAfiliacionController : BaseApiController
{
    private readonly IMediator _mediator;
    private readonly ILogger<AfiliadoFormulariosAfiliacionController> _logger;

    public AfiliadoFormulariosAfiliacionController(IMediator mediator, ILogger<AfiliadoFormulariosAfiliacionController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(CodeErrorResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<int>> AfiliadoFormulariosAfiliacionsCreate([FromBody] AfiliadoFormulariosAfiliacionCreateCommand body)
    {
        var list = await _mediator.Send(body);

        return Ok(list);
    }

    [HttpPost("GetAfiliadosFAWithSpec", Name = "GetAfiliadosFAAll")]
    //[Authorize]
    [ProducesResponseType(typeof(Pagination<AfiliadoFormulariosAfiliacionVm>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<Pagination<AfiliadoFormulariosAfiliacionVm>>> GetAfiliadosFAWithSpec([FromBody] GetAfiliadoFAListQuery query)
    {
        _logger.LogInformation("Query", query);
        //var query = new GetPadronListQuery(parameters);
        var padrones = await _mediator.Send(query);

        return Ok(padrones);
    }
}
