using MediatR;

namespace CleanArchitecture.Application.Features.SeccionalContacto.Command.UpdateSeccionalContacto;

public class UpdateSeccionalContactoCommand : IRequest<int>
{
    public int Id { get; set; }
    public int SeccionalId { get; set; }
    public string? Tipo { get; set; }
    public string? Detalle { get; set; }
}
