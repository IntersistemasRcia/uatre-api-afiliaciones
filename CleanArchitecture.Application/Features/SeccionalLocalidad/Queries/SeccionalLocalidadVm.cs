using CleanArchitecture.Domain.Commom;

namespace CleanArchitecture.Application.Features.SeccionalLocalidad.Queries;

public class SeccionalLocalidadVm
{
    public int Id { get; set; }
    public int RefLocalidadId { get; set; }
    public int CodPostal { get; set; }
    public string? Nombre { get; set; }
    public string? Codigo { get; set; }
    public string? LitProvincia { get; set; }
    public int SeccionalId { get; set; }
    public string? SeccionalDescripcion { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? DeletedDate { get; set; }
    public string? DeletedBy { get; set; }
    public string? DeletedObs { get; set; }
}
