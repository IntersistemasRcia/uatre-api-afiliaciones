namespace CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresas.Commands.ResolverSolicitud;

public class PatchSolicitudEstadoDto
{
    public required int EstadoSolicitudId { get; set; }
    public string? EstadoSolicitudObservaciones { get; set; }
    public string? EstadoSolicitudUsuario { get; set; }
    public DateTime? EstadoFecha { get; set; }

}
