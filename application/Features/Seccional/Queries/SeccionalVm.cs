using CleanArchitecture.Application.Features.SeccionalLocalidad.Queries;
using CleanArchitecture.Domain.Commom;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.Features.Seccional.Queries;

public class SeccionalVm
{
    public int Id { get; set; }
    public string? Codigo { get; set; }
    public string? Descripcion { get; set; }
    public string? Domicilio { get; set; }
    public int SeccionalEstadoId { get; set; }
    public string? SeccionalEstadoDescripcion { get; set; }
    public string? Observaciones { get; set; }
    public int RefLocalidadesId { get; set; }
    public string? LocalidadNombre { get; set; }
    public int LocalidadCodPostal { get; set; }
    public int ProvinciaId { get; set; }
    public string? ProvinciaDescripcion { get; set; }
    public int RefDelegacionId { get; set; }
    public string? RefDelegacionDescripcion { get; set; }
    public string? Email { get; set; }
    public float Latitud { get; set; }
    public float Longitud { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? DeletedDate { get; set; }
    public string? DeletedBy { get; set; }
    public string? DeletedObs { get; set; }
    public int SeccionalAbsorbenteId { get; set; }
    public string? SeccionalAbsorbenteCodigo { get; set; }
    public string? SeccionalAbsorbenteDescripcion { get; set; }

    public TimeOnly? HorarioAtencion1Desde { get; set; }
    public TimeOnly? HorarioAtencion1Hasta { get; set; }
    public TimeOnly? HorarioAtencion2Desde { get; set; }
    public TimeOnly? HorarioAtencion2Hasta { get; set; }
    public string? Telefono { get; set; }
    public string? TelefonoSecretarioGeneral { get; set; }
    public ICollection<SeccionalLocalidadVm>? SeccionalLocalidad { get; set; }
}

//public class SeccionalLocalidadVm
//{
//    public int Id { get; set; }
//    public string? Nombre { get; set; }
//    public string? Codigo { get; set; }
//    public string? LitProvincia { get; set; }
//}
