using MediatR;

namespace CleanArchitecture.Application.Features.SeccionalLocalidad.Command.ReactivarSeccionalLocalidad;

public class ReactivarSeccionalLocalidadCommand : IRequest<int>
{
    public int Id { get; set; }
}
