using CleanArchitecture.API.Errors;
using CleanArchitecture.Application.Features.Notificaciones.Commands.NotificacionesCreate;
using CleanArchitecture.Application.Features.Notificaciones.Commands.NotificacionesUpdate;
using CleanArchitecture.Application.Features.Notificaciones.Queries;
using CleanArchitecture.Application.Features.Notificaciones.Queries.NotificacionesGet;
using CleanArchitecture.Application.Features.Notificaciones.Queries.NotificacionesGetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Controllers;

public class NotificacionesController : BaseApiController
{
    private readonly IMediator _mediator;

    public NotificacionesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{Id}")]
    [ProducesResponseType(typeof(NotificacionesResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(CodeErrorResponse), (int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<NotificacionesResponse>> NotificacionesGetById(int Id)
    {
        var query = new NotificacionesGetByIdQuery(Id);
        var list = await _mediator.Send(query);

        return Ok(list);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<NotificacionesResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IReadOnlyList<NotificacionesResponse>>> NotificacionesGet([FromQuery] NotificacionesGetQuery query)
    {
        var list = await _mediator.Send(query);

        return Ok(list);
    }

    [HttpPost]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(CodeErrorResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<int>> NotificacionesCreate([FromBody] NotificacionesCreateCommand body)
    {
        var list = await _mediator.Send(body);

        return Ok(list);
    }

    [HttpPut("{Id}")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(CodeErrorResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<int>> NotificacionesUpdate(int Id, [FromBody] NotificacionesUpdateDTO body)
    {
        var command = new NotificacionesUpdateCommand(Id, body);
        var list = await _mediator.Send(command);

        return Ok(list);
    }
}
