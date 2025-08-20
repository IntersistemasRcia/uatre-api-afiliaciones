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
using CleanArchitecture.Application.Features.GestionOsprera.Commands.GestionOspreraCreate;
using CleanArchitecture.Application.Features.GestionOsprera.Queries;
using CleanArchitecture.Application.Features.GestionOsprera.Queries.GetGestionOspreraList;
using CleanArchitecture.Application.Features.Seccional.Command.Update;
using CleanArchitecture.Application.Features.GestionOsprera.Commands.Update;
using CleanArchitecture.Application.Features.GestionOsprera.Commands.GestionOsprera;
using CleanArchitecture.Application.Features.Seccional.Command.Reactivar;
using CleanArchitecture.Application.Features.GestionOsprera.Commands.GestionOspreraDarDeBaja;
using CleanArchitecture.Application.Features.GestionOsprera.Commands.GestionOspreraReactivar;
using CleanArchitecture.Application.Features.GestionOsprera.Queries.GetByPersona;

namespace CleanArchitecture.API.Controllers;

public class GestionOspreraController : BaseApiController
{
    private readonly IMediator _mediator;
    private readonly ILogger<GestionOspreraController> _logger;

    public GestionOspreraController(IMediator mediator, ILogger<GestionOspreraController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(CodeErrorResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<int>> GestionOspreraCreate([FromBody] GestionOspreraCreateCommand body)
    {
        var list = await _mediator.Send(body);

        return Ok(list);
    }

    [HttpPost("GetGestionOSpreraSpec", Name = "GetGestionOspreraAll")]
    //[Authorize]
    [ProducesResponseType(typeof(Pagination<GestionOspreraVm>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<Pagination<GestionOspreraVm>>> GetGestionOspreraWithSpec([FromBody] GetGestionOspreraListQuery query)
    {
        _logger.LogInformation("Query", query);
        //var query = new GetPadronListQuery(parameters);
        var padrones = await _mediator.Send(query);

        return Ok(padrones);
    }

    [HttpPut]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<int>> Update([FromBody] UpdateGestionOspreraCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPatch("DarDeBaja")]
    public async Task<ActionResult<int>> DarDeBaja([FromBody] GestionOspreraDarDeBajaCommand request)
    {
        var response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpPatch("Reactivar")]
    public async Task<ActionResult<int>> Reactivar([FromBody] GestionOspreraReactivarCommand request)
    {
        var response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpGet("CUIT")]
    [ProducesResponseType(typeof(GestionOspreraVm), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(CodeErrorResponse), (int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<GestionOspreraVm>> GetByCUITAsync([FromQuery] GestionOspreraGetByCUITQuery query)
    {
        var gestion = await _mediator.Send(query);
        return Ok(gestion);
    }
}
