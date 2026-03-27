using MediatR;

namespace CleanArchitecture.Application.Features.SeccionalContacto.Command.ReactivarSeccionalContacto;

public class ReactivarSeccionalContactoCommand : IRequest<int>
{
    public int Id { get; set; }
}
