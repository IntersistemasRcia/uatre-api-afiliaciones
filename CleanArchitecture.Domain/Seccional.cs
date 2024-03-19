using CleanArchitecture.Domain.Commom;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain;

public class Seccional : EntidadAuditable
{
    [StringLength(30)]
    public string? Codigo { get; set; }

    [StringLength(100)]
    public string? Descripcion { get; set; }

    [StringLength(100)]
    public string? Domicilio { get; set; }

    [StringLength(2000)]
    public string? Observaciones { get; set; } 
    
    public int RefDelegacionId { get; set; }   
    
    public int RefLocalidadesId { get; set; }

    public RefLocalidad? RefLocalidades { get; set; }

    [StringLength(1000)]
    public string? Email { get; set; }

    public int SeccionalEstadoId { get; set; }

    public SeccionalEstado? SeccionalEstado { get; set; }

    public float Latitud { get; set; }

    public float Longitud { get; set; }

    [NotMapped]
    public string? RefDelegacionDescripcion { get; set; }

    public ICollection<SeccionalLocalidad>? SeccionalLocalidad { get; set; }

    public ICollection<SeccionalContacto>? SeccionalContacto { get; set; }

    public ICollection<SeccionalAutoridad>? SeccionalAutoridades { get; set; }
}
