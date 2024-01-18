using MediatR;

namespace CleanArchitecture.Application.Features.RefLocalidad.Command.ReactivarRefLocalidad;

public class ReactivarRefLocalidadCommand : IRequest<int>
{
    public int Id { get; set; }
}
