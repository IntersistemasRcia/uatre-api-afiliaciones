using CleanArchitecture.Application.Features.GestionesAreaOsprera.Queries.GestionesAreaOspreraAll;
using CleanArchitecture.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers;

public class GestionesAreaOspreraController : BaseApiController
{
    private readonly IMediator _mediator;

    public GestionesAreaOspreraController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "GestionesAreaOspreraAll")]
    //[Authorize]
    [ProducesResponseType(typeof(IReadOnlyList<IdDescripcionVm>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IReadOnlyCollection<IdDescripcionVm>>> GestionesAreaOspreraAll()
    {
        var query = new GestionesAreaOspreraAllQuery();
        var list = await _mediator.Send(query);

        return Ok(list);
    }
}
