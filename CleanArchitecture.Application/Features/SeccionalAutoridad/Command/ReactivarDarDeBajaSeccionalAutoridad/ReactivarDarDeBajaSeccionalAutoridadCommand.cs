using MediatR;

namespace CleanArchitecture.Application.Features.SeccionalAutoridad.Command.ReactivarSeccionalAutoridad;

public class ReactivarDarDeBajaSeccionalAutoridadCommand : IRequest<int>
{
    public int Id { get; set; }
}
