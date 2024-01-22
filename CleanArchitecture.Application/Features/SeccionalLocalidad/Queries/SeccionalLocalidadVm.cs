using CleanArchitecture.Domain.Commom;

namespace CleanArchitecture.Application.Features.SeccionalLocalidad.Queries;

public class SeccionalLocalidadVm : EntidadAuditable
{
    public int RefLocalidadId { get; set; }
    public int CodPostal { get; set; }
    public string? Nombre { get; set; }
    public string? Codigo { get; set; }
    public string? LitProvincia { get; set; }
    public int SeccionalId { get; set; }
    public string? SeccionalDescripcion { get; set; }
}
