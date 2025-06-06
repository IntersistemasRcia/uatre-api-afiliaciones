using CleanArchitecture.Application.Features.GestionesRubro.Queries;
using CleanArchitecture.Application.Features.GestionesRubro.Queries.GestionesRubroAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers;

public class GestionesRubroController : BaseApiController
{
    private readonly IMediator _mediator;

    public GestionesRubroController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "GestionesRubroAll")]
    //[Authorize]
    [ProducesResponseType(typeof(IReadOnlyList<GestionRubroVm>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IReadOnlyCollection<GestionRubroVm>>> GestionesRubroAll()
    {
        var query = new GestionesRubroAllQuery();
        var list = await _mediator.Send(query);

        return Ok(list);
    }
}
