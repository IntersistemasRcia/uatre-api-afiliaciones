using CleanArchitecture.Application.Features.SeccionalLocalidad.Queries;
using CleanArchitecture.Domain.Commom;

namespace CleanArchitecture.Application.Features.Seccional.Queries;

public class SeccionalVm : EntidadAuditable
{
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
    public ICollection<SeccionalLocalidadVm>? SeccionalLocalidad { get; set; }
}

//public class SeccionalLocalidadVm
//{
//    public int Id { get; set; }
//    public string? Nombre { get; set; }
//    public string? Codigo { get; set; }
//    public string? LitProvincia { get; set; }
//}
