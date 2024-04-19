namespace CleanArchitecture.Application.Features.Notificaciones.Commands.NotificacionesUpdate;

public class NotificacionesUpdateDTO
{
    public required string TipoNotificacion { get; set; }

    public required int DestinoId { get; set; }

    public required string Email { get; set; }

    public required string Asunto { get; set; }

    public required string Cuerpo { get; set; }

    public string Observaciones { get; set; } = string.Empty;

    public required string Estado { get; set; }

    public required byte[] Archivo { get; set; }

    public required string Adjuntos { get; set; }

    public ICollection<NotificacionDetalleUpdateCommand>? NotificacionesDetalle { get; set; }
}
