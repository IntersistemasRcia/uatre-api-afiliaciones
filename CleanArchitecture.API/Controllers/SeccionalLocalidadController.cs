using CleanArchitecture.Application.Features.SeccionalContacto.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using MediatR;
using CleanArchitecture.Application.Features.SeccionalLocalidad.Queries.GetSeccionalLocalidadBySeccionalId;
using CleanArchitecture.Application.Features.SeccionalLocalidad.Queries;
using CleanArchitecture.Application.Features.SeccionalLocalidad.Command.UpdateSeccionalLocalidad;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using CleanArchitecture.Application.Features.SeccionalLocalidad.Command.DarDeBajaSeccionalLocalidad;
using CleanArchitecture.Application.Features.SeccionalLocalidad.Command.ReactivarSeccionalLocalidad;

namespace CleanArchitecture.API.Controllers;

public class SeccionalLocalidadController : BaseApiController
{
    private readonly IMediator _mediator;
    public SeccionalLocalidadController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetSeccionalLocalidadBySeccionalId", Name = "GetSeccionalLocalidadBySeccionalId")]
    //[Authorize]
    [ProducesResponseType(typeof(IReadOnlyCollection<SeccionalLocalidadVm>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IReadOnlyCollection<SeccionalLocalidadVm>>> GetSeccionalLocalidadBySeccionalId([FromQuery] GetSeccionalLocalidadBySeccionalIdCommand query)
    {
        var data = await _mediator.Send(query);

        return Ok(data);
    }

    [HttpPut]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> UpdateSeccionalLocalidad([FromBody] UpdateSeccionalLocalidadCommand request)
    {
        var result = await _mediator.Send(request);

        return Ok(result);
    }

    [HttpPatch("DarDeBaja")]
    public async Task<ActionResult<int>> DarDeBaja([FromBody] DarDeBajaSeccionalLocalidadCommand request)
    {
        var response = await _mediator.Send(request);

        return Ok(response);
    }

    [HttpPatch("Reactivar")]
    public async Task<ActionResult<int>> Reactivar([FromBody] ReactivarSeccionalLocalidadCommand request)
    {
        var response = await _mediator.Send(request);

        return Ok(response);
    }
}
