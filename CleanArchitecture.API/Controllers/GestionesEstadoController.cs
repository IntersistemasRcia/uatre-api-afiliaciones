using CleanArchitecture.Application.Features.GestionesEstado.Queries.GestionesEstadoAll;
using CleanArchitecture.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers;

public class GestionesEstadoController : BaseApiController
{
    private readonly IMediator _mediator;

    public GestionesEstadoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "GestionesEstadoAll")]
    //[Authorize]
    [ProducesResponseType(typeof(IReadOnlyList<IdDescripcionVm>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IReadOnlyCollection<IdDescripcionVm>>> GestionesEstadoAll()
    {
        var query = new GestionesEstadoAllQuery();
        var list = await _mediator.Send(query);

        return Ok(list);
    }
}
