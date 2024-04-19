using CleanArchitecture.Domain.Commom;
using CleanArchitecture.Domain;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.Features.Notificaciones.Queries;

public class NotificacionesResponse
{
    public int Id { get; set; }
    public string TipoNotificacion { get; set; } = string.Empty;

    public int DestinoId { get; set; }

    public string Email { get; set; } = string.Empty;

    public string Asunto { get; set; } = string.Empty;

    public string Cuerpo { get; set; } = string.Empty;

    public string Observaciones { get; set; } = string.Empty;

    public DateTime FechaEnvio { get; set; }

    public string Estado { get; set; } = string.Empty;

    public byte[]? Archivo { get; set; }

    public string Adjuntos { get; set; } = string.Empty;

    public Guid? Guid { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? DeletedDate { get; set; }
    
    public string? DeletedBy { get; set; }
    
    public string? DeletedObs { get; set; }

    public ICollection<NotificacionesDetalleResponse>? NotificacionesDetalle { get; set; }
}

public class NotificacionesDetalleResponse
{
    public string? TipoNotificado { get; set; }
    public int NotificadoId { get; set; }
    public string? Observaciones { get; set; }
}