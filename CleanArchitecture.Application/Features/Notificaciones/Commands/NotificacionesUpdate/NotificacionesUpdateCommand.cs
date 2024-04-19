using MediatR;

namespace CleanArchitecture.Application.Features.Notificaciones.Commands.NotificacionesUpdate;

public class NotificacionesUpdateCommand : IRequest<int>
{
    public NotificacionesUpdateCommand(int id, NotificacionesUpdateDTO body)
    {
        Id = id;
        TipoNotificacion = body.TipoNotificacion;
        DestinoId = body.DestinoId;
        Email = body.Email;
        Asunto = body.Asunto;
        Cuerpo = body.Cuerpo;
        Observaciones = body.Observaciones;
        Estado = body.Estado;
        Archivo = body.Archivo;
        Adjuntos = body.Adjuntos;
        NotificacionesDetalle = body.NotificacionesDetalle;
    }

    public  int Id { get; set; }
    public  string TipoNotificacion { get; set; }

    public  int DestinoId { get; set; }

    public  string Email { get; set; }

    public  string Asunto { get; set; }

    public  string Cuerpo { get; set; }

    public string Observaciones { get; set; } = string.Empty;

    public  string Estado { get; set; }

    public  byte[] Archivo { get; set; }

    public  string Adjuntos { get; set; }

    public ICollection<NotificacionDetalleUpdateCommand>? NotificacionesDetalle { get; set; }
}

public class NotificacionDetalleUpdateCommand
{
    public int Id { get; set; }
    public int NotificacionesId { get; set; }
    public string? TipoNotificado { get; set; }
    public int NotificadoId { get; set; }
    public string? Observaciones { get; set; }
}
