using CleanArchitecture.Application.Features.SeccionalLocalidad.Queries;
using MediatR;

namespace CleanArchitecture.Application.Features.SeccionalLocalidad.Command.AbsorbeSeccionalLocalidad;

public class AbsorbeSeccionalLocalidadCommand : IRequest<int>
{
    public int SeccionalIdAbsorbida { get; set; }
    public int SeccionalIdAbsorbente { get; set; }
    public string? UserId { get; set; }
}
