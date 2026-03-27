using MediatR;

namespace CleanArchitecture.Application.Features.SeccionalEstado.Commands.CreateSeccionalEstado;

public class CreateSeccionalEstadoCommand : IRequest<int>
{
    public string? Descripcion { get; set; }
}
