using MediatR;

namespace CleanArchitecture.Application.Features.Afiliado.Commands.ResolverSolicitudAfiliado;

public class PatchAfiliadoCommand : IRequest<int>
{
    public PatchAfiliadoCommand(int afiliadoId, PatchAfiliadoDto dto)
    {
        Id = afiliadoId;
        EstadoSolicitudId = dto.EstadoSolicitudId;
        FechaEgreso = dto.FechaEgreso;
        FechaIngreso = dto.FechaIngreso;
    }

    public int Id { get; set; }
    public int EstadoSolicitudId { get; set; }
    public DateTime? FechaIngreso { get; set; }
    public DateTime? FechaEgreso { get; set; }
}
