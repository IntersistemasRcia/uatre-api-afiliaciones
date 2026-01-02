using MediatR;

namespace CleanArchitecture.Application.Features.SeccionalAutoridad.Command.DarDeBajaSeccionalAutoridad;

public class DarDeBajaSeccionalAutoridadCommand : IRequest<int>
{
    public int Id { get; set; }
    public string? DeletedObs { get; set; }
}
