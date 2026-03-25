using CleanArchitecture.Application.Features.SeccionalContacto.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using MediatR;
using CleanArchitecture.Application.Features.SeccionalLocalidad.Queries.GetSeccionalLocalidadBySeccionalId;
using CleanArchitecture.Application.Features.SeccionalLocalidad.Queries;
using CleanArchitecture.Application.Features.SeccionalLocalidad.Command.UpdateSeccionalLocalidad;
using CleanArchitecture.Application.Features.SeccionalLocalidad.Command.DarDeBajaSeccionalLocalidad;
using CleanArchitecture.Application.Features.SeccionalLocalidad.Command.ReactivarSeccionalLocalidad;
using CleanArchitecture.Application.Features.SeccionalLocalidad.Queries.GetSeccionalLocalidadByRefLocalidadId;
using CleanArchitecture.Application.Features.SeccionalLocalidad.Command.CreateSeccionalLocalidad;
using CleanArchitecture.Application.Features.SeccionalLocalidad.Command.UpdateRecordSeccionalLocalidad;
using CleanArchitecture.Application.Features.SeccionalAutoridad.Command.CreateSeccionalAutoridad;
using CleanArchitecture.Application.Features.SeccionalLocalidad.Command.AbsorbeSeccionalLocalidad;
using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.API.Controllers;

public class SeccionalLocalidadController : BaseApiController
{
    private readonly IMediator _mediator;
    private readonly AfiliacionesDbContext _context;
    public SeccionalLocalidadController(IMediator mediator, AfiliacionesDbContext context)
    {
        _mediator = mediator;
        _context = context;
    }

    [HttpGet("GetSeccionalLocalidadBySeccionalId", Name = "GetSeccionalLocalidadBySeccionalId")]
    //[Authorize]
    [ProducesResponseType(typeof(IReadOnlyCollection<SeccionalLocalidadVm>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IReadOnlyCollection<SeccionalLocalidadVm>>> GetSeccionalLocalidadBySeccionalId([FromQuery] GetSeccionalLocalidadBySeccionalIdCommand query)
    {
        var data = await _mediator.Send(query);

        return Ok(data);
    }

    [HttpGet("GetSeccionalLocalidadByRefLocalidadId", Name = "GetSeccionalLocalidadByRefLocalidadId")]
    //[Authorize]
    [ProducesResponseType(typeof(IReadOnlyCollection<SeccionalLocalidadVm>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IReadOnlyCollection<SeccionalLocalidadVm>>> GetSeccionalLocalidadByRefLocalidadId([FromQuery] GetSeccionalLocalidadByRefLocalidadIdCommand query)
    {
        var data = await _mediator.Send(query);
        return Ok(data);
    }

    [HttpPost]
    [ProducesResponseType(typeof(SeccionalLocalidadVm), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<SeccionalLocalidadVm>> UpdateSeccionalLocalidad([FromBody] CreateSeccionalLocalidadCommand request)
    {
        var result = await _mediator.Send(request);

        return Ok(result);
    }

    [HttpPost("AbsorbeSeccionalLocalidades")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> AbsorbeSeccionalLocalidades([FromBody] AbsorbeSeccionalLocalidadCommand query)
    {
        
        var afiliadosAbsorbidos = await _context.Database.ExecuteSqlInterpolatedAsync($@"EXEC 
                    spSeccionalAbsorbe
                    @SeccionalAbsorbidaId={query.SeccionalIdAbsorbida},
	                @SeccionalAbsorbenteId={query.SeccionalIdAbsorbente},
                    @UserId={query.UserId}");
        
        return await _mediator.Send(query);   
    }




  /*
    [ProducesResponseType(typeof(List<SeccionalAutoridadResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<List<SeccionalAutoridadResponse>>> GetSeccionalAutoridadBySpecs([FromQuery] GetSeccionalAutoridadBySpecsQuery query)
  */

    [HttpPut]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> UpdateSeccionalLocalidad([FromBody] UpdateSeccionalLocalidadCommand request)
    {
        var result = await _mediator.Send(request);

        return Ok(result);
    }

    [HttpPut("UpdateRecordSeccionalLocalidad")]
    [ProducesResponseType(typeof(SeccionalLocalidadVm), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<SeccionalLocalidadVm>> UpdateRecordSeccionalLocalidad([FromBody] UpdateRecordSeccionalLocalidadCommand request)
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
