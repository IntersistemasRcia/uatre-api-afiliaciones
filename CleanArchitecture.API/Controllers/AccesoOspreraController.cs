using CleanArchitecture.API.Errors;
using CleanArchitecture.Application.Features.Afiliado.Queries.GetAfiliadoList;
using CleanArchitecture.Application.Features.Afiliado.Queries;
using CleanArchitecture.Application.Features.AfiliadoFormulariosAfiliacion.Commands.AfiliadoFormulariosAfiliacionCreate;
using CleanArchitecture.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using CleanArchitecture.Application.Features.AfiliadoFormulariosAfiliacion.Queries.GetAfiliadoFormularioAfiliacionList;
using CleanArchitecture.Application.Features.Seccional.Command.DarDeBaja;
using CleanArchitecture.Application.Features.AfiliadoFormulariosAfiliacion.Command.ResuelveFormularioAfiliacion;
using CleanArchitecture.Application.Features.AccesoOsprera.Commands.AccesoOspreraCreate;
using CleanArchitecture.Application.Features.AccesoOsprera.Queries;
using CleanArchitecture.Application.Features.AccesoOsprera.Queries.GetAccesoOspreraList;

namespace CleanArchitecture.API.Controllers;

public class AccesoOspreraController : BaseApiController
{
    private readonly IMediator _mediator;
    private readonly ILogger<AccesoOspreraController> _logger;

    public AccesoOspreraController(IMediator mediator, ILogger<AccesoOspreraController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(CodeErrorResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<int>> AccesoOspreraCreate([FromBody] AccesoOspreraCreateCommand body)
    {
        var list = await _mediator.Send(body);

        return Ok(list);
    }

    [HttpPost("GetAccesoOSpreraSpec", Name = "GetAccesoOspreraAll")]
    //[Authorize]
    [ProducesResponseType(typeof(Pagination<AccesoOspreraVm>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<Pagination<AccesoOspreraVm>>> GetAccesoOspreraWithSpec([FromBody] GetAccesoOspreraListQuery query)
    {
        _logger.LogInformation("Query", query);
        //var query = new GetPadronListQuery(parameters);
        var padrones = await _mediator.Send(query);

        return Ok(padrones);
    }
    /*
    [HttpPatch("ResuelveFormularioAfiliacion")]
    public async Task<ActionResult<int>> ResuelveFormularioAfiliacion([FromBody] ResuelveFormularioAfiliacionCommand request)
    {
        var response = await _mediator.Send(request);

        return Ok(response);
    }*/
}
