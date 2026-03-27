using CleanArchitecture.Domain.Commom;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain;

public class InformeSap : EntidadAuditable
{
    public DateTime FechaHora { get; set; }

    [StringLength(300)]
    public required string NombreArchivo { get; set; }

    [StringLength(100)]
    public required string CarpetaFtp { get; set; }

    [StringLength(300)]
    public string Observaciones { get; set; } = string.Empty;

    public ICollection<InformeSapDetalle>? InformeSapDetalles { get; set; }
}
