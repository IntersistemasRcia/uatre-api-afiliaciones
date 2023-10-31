using MediatR;

namespace CleanArchitecture.Application.Features.SeccionalContacto.Command.DarDeBajaSeccionalContacto;

public class DarDeBajaSeccionalContactoCommand : IRequest<int>
{
    public int Id { get; set; }
    public string? DeletedObs { get; set; }
}
