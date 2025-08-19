using CleanArchitecture.Application.Features.GestionesObraSocial;
using CleanArchitecture.Application.Features.GestionesObraSocial.Queries.GetAll;
using CleanArchitecture.Application.Features.GestionesRubro.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers;

public class GestionesObraSocialController : BaseApiController
{
    private readonly IMediator _mediator;

    public GestionesObraSocialController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    //[Authorize]
    [ProducesResponseType(typeof(IReadOnlyList<GestionRubroVm>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IReadOnlyCollection<GestionObraSocialVm>>> GestionesObraSocialGetAll()
    {
        var query = new GestionesObraSocialGetAllQuery();
        var list = await _mediator.Send(query);

        return Ok(list);
    }
}
