using CleanArchitecture.Application.Features.GestionesSituacion.Queries.GestionesSituacionByEstado;
using CleanArchitecture.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers;

public class GestionesSituacionController : BaseApiController
{
    private readonly IMediator _mediator;

    public GestionesSituacionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "GestionesSituacionByEstado")]
    //[Authorize]
    [ProducesResponseType(typeof(IReadOnlyList<IdDescripcionVm>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IReadOnlyCollection<IdDescripcionVm>>> GestionesSituacionByEstado([FromQuery] GestionesSituacionByEstadoQuery query)
    {
        var list = await _mediator.Send(query);

        return Ok(list);
    }
}

