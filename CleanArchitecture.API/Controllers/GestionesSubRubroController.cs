using CleanArchitecture.Application.Features.GestionesRubro.Queries;
using CleanArchitecture.Application.Features.GestionesSubRubro;
using CleanArchitecture.Application.Features.GestionesSubRubro.Queries.GestionesSubRubroByRubro;
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

    [HttpGet(Name = "GestionesSubRubroByRubro")]
    //[Authorize]
    [ProducesResponseType(typeof(IReadOnlyList<GestionRubroVm>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IReadOnlyCollection<GestionSubRubroVm>>> GestionesSubRubroByEstado([FromQuery] GestionesSubRubroByRubroQuery query)
    {
        var list = await _mediator.Send(query);

        return Ok(list);
    }
}
