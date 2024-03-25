using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Features.Afiliado.Queries.GetAfiliadoList;
using CleanArchitecture.Application.Features.Afiliado.Queries;
using CleanArchitecture.Application.Features.Afiliado.Commands.CreateAfiliado;
using CleanArchitecture.Application.Features.Afiliado.Queries.GetAfiliadoByCUIL;
using CleanArchitecture.Application.Features.Afiliado.Commands.ResolverSolicitudAfiliado;
using CleanArchitecture.Common.Exceptions;
using CleanArchitecture.Application.Features.Afiliado.Commands.UpdateAfiliado;
using CleanArchitecture.Application.Features.Afiliado.Commands.UpdateDatosAfip;
using CleanArchitecture.Application.Features.Afiliado.Queries.GetAfiliadoById;

namespace CleanArchitecture.API.Controllers;

public class AfiliadoController : BaseApiController
{
    private readonly IMediator _mediator;
    private readonly ILogger<AfiliadoController> _logger;

    public AfiliadoController(IMediator mediator, ILogger<AfiliadoController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost("GetAfiliadosWithSpec", Name = "GetAfiliadosAll")]
    //[Authorize]
    [ProducesResponseType(typeof(Pagination<AfiliadoVm>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<Pagination<AfiliadoVm>>> GetAfiliadosWithSpec([FromBody] GetAfiliadoListQuery query)
    {
        _logger.LogInformation("Query", query);
        //var query = new GetPadronListQuery(parameters);
        var padrones = await _mediator.Send(query);

        return Ok(padrones);
    }

    [HttpGet("{id}")]
    //[Authorize]
    [ProducesResponseType(typeof(AfiliadoVm), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(AfiliadoVm), (int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<AfiliadoVm>> GetAfiliadoById(int id)
    {
        var query = new GetAfiliadoByIdQuery(id);
        var padrones = await _mediator.Send(query);

        return Ok(padrones);
    }

    [HttpGet("GetAfiliadoByCUIL", Name = "GetAfiliado")]
    //[Authorize]
    [ProducesResponseType(typeof(AfiliadoVm), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(AfiliadoVm), (int)HttpStatusCode.NotFound)]
    public async Task<ActionResult<AfiliadoVm>> GetAfiliado([FromQuery] GetAfiliadoByCUILQuery query)
    {
        //var query = new GetPadronListQuery(parameters);
        var padrones = await _mediator.Send(query);

        return Ok(padrones);
    }

    [HttpPost(Name = "CreateAfiliado")]
    //[Authorize(Roles = "Administrator")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<ActionResult<int>> CreateAfiliado([FromBody] CreateAfiliadoCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPatch("PatchAfiliado/{afiliadoId}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<ActionResult<int>> PatchAfiliado(int afiliadoId, [FromBody] PatchAfiliadoDto dto)
    {
        if (!ModelState.IsValid)
        {
            throw new BadRequestException("Error");
        }

        var command = new PatchAfiliadoCommand(afiliadoId, dto);
        return await _mediator.Send(command);
    }

    [HttpPut(Name = "UpdateAfiliado")]
    //[Authorize(Roles = "Administrator")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<ActionResult<int>> UpdateAfiliado([FromBody] UpdateAfiliadoCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPatch("ActualizarDatosAfip/{afiliadoId}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<ActionResult<int>> ActualizarDatosAfip(int afiliadoId, [FromBody] PatchAfiliadoDatosAfipDto dto)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError("BadRequest");
            throw new BadRequestException("Error");
        }

        var command = new PatchAfiliadoDatosAfipCommand(afiliadoId, dto);
        return await _mediator.Send(command);
    }
}
