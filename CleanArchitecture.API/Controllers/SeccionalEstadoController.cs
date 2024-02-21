using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using CleanArchitecture.Application.Features.SeccionalEstado.Responses;
using CleanArchitecture.Application.Features.SeccionalEstado.Queries.GetSeccionalEstadoAll;
using CleanArchitecture.Application.Features.SeccionalEstado.Queries.GetSeccionalEstadoById;
using CleanArchitecture.Application.Features.SeccionalEstado.Commands.CreateSeccionalEstado;
using CleanArchitecture.Application.Features.SeccionalEstado.Commands.UpdateSeccionalEstado;

namespace CleanArchitecture.API.Controllers;

public class SeccionalEstadoController : BaseApiController
{
    private readonly IMediator _mediator;

    public SeccionalEstadoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    //[Authorize]
    [ProducesResponseType(typeof(List<SeccionalEstadoResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<List<SeccionalEstadoResponse>>> GetSeccionalEstadoAll()
    {
        var query = new GetSeccionalEstadoAllQuery();
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpGet("{Id}")]
    //[Authorize]
    [ProducesResponseType(typeof(SeccionalEstadoResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<SeccionalEstadoResponse>> GetSeccionalEstadoById(int Id)
    {
        var query = new GetSeccionalEstadoByIdQuery(Id);
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpPost]
    //[Authorize(Roles = "Administrator")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<int>> CreateSeccionalEstado([FromBody] CreateSeccionalEstadoCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPut("{Id}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<int>> UpdateSeccionalEstado(int Id, [FromBody] UpdateSeccionalEstadoDto request)
    {
        var command = new UpdateSeccionalEstadoCommand(Id, request.Descripcion!);
        var response = await _mediator.Send(request);

        return Ok(response);
    }
}
