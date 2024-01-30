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
    [StringLength(20)]
    [RegularExpression("^Normalizada$|^Transitoria$|^Acefala$|^Fusionada$|^Activa$|^Inactiva$", ErrorMessage = "Valor NO Aceptado")]
    public string? Estado { get; set; }
    public int RefDelegacionId { get; set; }        
    public int RefLocalidadesId { get; set; }
    public RefLocalidad? RefLocalidades { get; set; }
    [StringLength(1000)]
    public string? Email { get; set; }
    [NotMapped]
    public string? RefDelegacionDescripcion { get; set; }
    public ICollection<SeccionalLocalidad>? SeccionalLocalidad { get; set; }
    public ICollection<SeccionalContacto>? SeccionalContacto { get; set; }
    public ICollection<SeccionalAutoridad>? SeccionalAutoridades { get; set; }
}

//public enum SeccionalEstado
//{
//    Normalizada = 'N',
//    Transitoria = 'T',
//    Acéfala = 'C',
//    Fusionada = 'U',
//    Activa = 'A',
//    Inactiva = 'I'
//}
