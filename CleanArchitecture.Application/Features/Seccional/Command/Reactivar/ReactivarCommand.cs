using MediatR;

namespace CleanArchitecture.Application.Features.Seccional.Command.Reactivar;

public class ReactivarCommand : IRequest<int>
{
    public int Id { get; set; }
}
