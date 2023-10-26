using CleanArchitecture.Domain.Commom;

namespace CleanArchitecture.Application.Features.RefLocalidad.Queries
{
    public class RefLocalidadVm : EntidadAuditable
    {
        public string? Nombre { get; set; }
        public int CodPostal { get; set; }
        public string? Provincia { get; set; }
       
    }
}
