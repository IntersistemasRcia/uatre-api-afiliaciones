using MediatR;

namespace CleanArchitecture.Application.Features.SeccionalEstado.Commands.UpdateSeccionalEstado;

public class UpdateSeccionalEstadoCommand : IRequest<int>
{
    public UpdateSeccionalEstadoCommand(int id, string descripcion)
    {
        Id = id;
        Descripcion = descripcion;
    }

    public int Id { get; private set; }
    public string? Descripcion { get; private set; }
}
