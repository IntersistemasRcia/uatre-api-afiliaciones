using CleanArchitecture.Domain.Commom;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain;

public class InformeSapDetalle : EntidadAuditable
{
    public int InformeSapId { get; set; }

    [StringLength(20)]
    public required string TipoInforme { get; set; }

    public int AfiliadoId { get; set; }
}
