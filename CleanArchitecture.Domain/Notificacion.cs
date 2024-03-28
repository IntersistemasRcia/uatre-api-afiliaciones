using CleanArchitecture.Domain.Commom;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain;

public class Notificacion : EntidadAuditable
{
    public required string TipoNotificacion { get; set; }

    public int DestinoId { get; set; }

    [StringLength(100)]
    public required string Email { get; set; }

    [StringLength(200)]
    public required string Asunto { get; set; }

    public required string Cuerpo { get; set; }

    [StringLength(500)]
    public string Observaciones { get; set; } = string.Empty;

    public DateTime FechaEnvio { get; set; }

    [StringLength(30)]
    public required string Estado { get; set; }

    public required byte[] Archivo { get; set; }
}
