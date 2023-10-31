using MediatR;

namespace CleanArchitecture.Application.Features.Seccional.Command.DarDeBaja;

public class DarDeBajaCommand : IRequest<int>
{
    public int Id { get; set; }
    public string? DeletedObs { get; set; }
}
