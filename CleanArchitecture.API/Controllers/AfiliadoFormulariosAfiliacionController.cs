using CleanArchitecture.API.Errors;
using CleanArchitecture.Application.Features.AfiliadoFormulariosAfiliacion.Commands.AfiliadoFormulariosAfiliacionCreate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers;

public class AfiliadoFormulariosAfiliacionController : BaseApiController
{
    private readonly IMediator _mediator;

    public AfiliadoFormulariosAfiliacionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(CodeErrorResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<int>> AfiliadoFormulariosAfiliacionsCreate([FromBody] AfiliadoFormulariosAfiliacionCreateCommand body)
    {
        var list = await _mediator.Send(body);

        return Ok(list);
    }
}
