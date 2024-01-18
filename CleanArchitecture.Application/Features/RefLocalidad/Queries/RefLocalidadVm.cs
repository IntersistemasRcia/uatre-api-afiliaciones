using CleanArchitecture.Domain.Commom;

namespace CleanArchitecture.Application.Features.RefLocalidad.Queries
{
    public class RefLocalidadVm : EntidadAuditable
    {
        public string? Nombre { get; set; }
        public int CodPostal { get; set; }
        public string? Provincia { get; set; }
        public int ProvinciaId { get; set; }
        public int SeccionalId { get; set; }
        public string? SeccionalDescripcion { get; set; }
        public string? SeccionalCodigo { get; set; }
    }
}
