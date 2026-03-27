using MediatR;

namespace CleanArchitecture.Application.Features.SeccionalLocalidad.Command.DarDeBajaSeccionalLocalidad;

public class DarDeBajaSeccionalLocalidadCommand : IRequest<int>
{
    public int Id { get; set; }
    public string? DeletedObs { get; set; }
}
