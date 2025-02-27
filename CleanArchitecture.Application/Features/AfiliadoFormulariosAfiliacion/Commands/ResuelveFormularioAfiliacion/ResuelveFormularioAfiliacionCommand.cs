using MediatR;

namespace CleanArchitecture.Application.Features.AfiliadoFormulariosAfiliacion.Command.ResuelveFormularioAfiliacion;

public class ResuelveFormularioAfiliacionCommand : IRequest<int>
{
    public int Id { get; set; }
    public int AfiliadoIdAsignado { get; set; }
    public string? DeletedObs { get; set; }
}
