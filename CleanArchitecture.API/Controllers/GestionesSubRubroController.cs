using CleanArchitecture.Application.Features.GestionesRubro.Queries;
using CleanArchitecture.Application.Features.GestionesSubRubro;
using CleanArchitecture.Application.Features.GestionesSubRubro.Queries.GestionesSubRubroByRubro;
using CleanArchitecture.Application.Features.GestionesSubRubro.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers;

public class GestionesSubRubroController : BaseApiController
{
    private readonly IMediator _mediator;

    public GestionesSubRubroController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("Rubro/{gestionRubroId}")]
    //[Authorize]
    [ProducesResponseType(typeof(IReadOnlyList<GestionRubroVm>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IReadOnlyCollection<GestionSubRubroVm>>> GestionesSubRubroByEstado(int gestionRubroId)
    {
        var list = await _mediator.Send(new GestionesSubRubroByRubroQuery(gestionRubroId));

        return Ok(list);
    }

    [HttpGet]
    //[Authorize]
    [ProducesResponseType(typeof(IReadOnlyList<GestionRubroVm>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IReadOnlyCollection<GestionSubRubroVm>>> GestionesSubRubroAll([FromQuery] GestionesSubRubroGetAllQuery query)
    {
        var list = await _mediator.Send(query);

        return Ok(list);
    }
}
