using MediatR;

namespace CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresas.Commands.ResolverSolicitud;

public class PatchSolicitudEstadoCommand : IRequest<int>
{
    public PatchSolicitudEstadoCommand(int afiliadoId, PatchSolicitudEstadoDto dto)
    {
        Id = afiliadoId;
        EstadoSolicitudId = dto.EstadoSolicitudId;
        EstadoSolicitudObservaciones = dto.EstadoSolicitudObservaciones;
        EstadoSolicitudUsuario = dto.EstadoSolicitudUsuario;
        EstadoFecha = dto.EstadoFecha;
    }

    public int Id { get; set; }
    public int EstadoSolicitudId { get; set; }
    public string? EstadoSolicitudObservaciones { get; set; }
    public string? EstadoSolicitudUsuario { get; set; }
    public DateTime? EstadoFecha { get; set; }
}
