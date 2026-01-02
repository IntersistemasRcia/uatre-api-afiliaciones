using MediatR;

namespace CleanArchitecture.Application.Features.SeccionalAutoridad.Command.ReactivarSeccionalAutoridad;

public class ReactivarSeccionalAutoridadCommand : IRequest<int>
{
    public int Id { get; set; }
}
