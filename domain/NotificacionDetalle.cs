using CleanArchitecture.Domain.Commom;

namespace CleanArchitecture.Domain;

public class NotificacionDetalle : EntidadAuditable
{
    public int NotificacionesId { get; set; }
    public string? TipoNotificado { get; set; }
    public int NotificadoId { get; set; }
    public string? Observaciones { get; set; }
}
