using MediatR;

namespace CleanArchitecture.Application.Features.Notificaciones.Commands.NotificacionesCreate;

public class NotificacionesCreateCommand : IRequest<int>
{
    public required string TipoNotificacion { get; set; }

    public required int DestinoId { get; set; }

    public required string Email { get; set; }

    public required string Asunto { get; set; }

    public required string Cuerpo { get; set; }

    public string Observaciones { get; set; } = string.Empty;

    public required DateTime FechaEnvio { get; set; }

    public required string Estado { get; set; }

    public byte[]? Archivo { get; set; }

    public required string Adjuntos { get; set; }

    public ICollection<NotificacionDetalleCreateCommand>? NotificacionesDetalle { get; set; }
}

public class NotificacionDetalleCreateCommand
{
    public string? TipoNotificado { get; set; }
    public int NotificadoId { get; set; }
    public string? Observaciones { get; set; }
}