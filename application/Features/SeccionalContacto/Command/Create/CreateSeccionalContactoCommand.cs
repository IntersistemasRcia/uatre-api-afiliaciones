using MediatR;

namespace CleanArchitecture.Application.Features.SeccionalContacto.Command.Create;

public class CreateSeccionalContactoCommand : IRequest<int>
{
    public int SeccionalId { get; set; }
    public string? Tipo { get; set; }
    public string? Detalle { get; set; }
}
