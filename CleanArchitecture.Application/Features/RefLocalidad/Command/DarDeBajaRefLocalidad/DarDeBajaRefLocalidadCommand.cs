using MediatR;

namespace CleanArchitecture.Application.Features.RefLocalidad.Command.DarDeBajaRefLocalidad;

public class DarDeBajaRefLocalidadCommand : IRequest<int>
{
    public int Id { get; set; }
    public string? DeletedObs { get; set; }
}
