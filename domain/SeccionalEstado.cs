using CleanArchitecture.Domain.Commom;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain;

public class SeccionalEstado : EntidadAuditable
{
    [StringLength(100)]
    public string Descripcion { get; set; } = string.Empty;
}
