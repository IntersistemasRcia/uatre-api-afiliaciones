using CleanArchitecture.Domain.Commom;

namespace CleanArchitecture.Application.Features.Provincia.Queries.GetProvinciasList
{
    public class ProvinciaVm : EntidadAuditable
    {
        public string? Nombre { get; set; }
        public int IdProvinciaAFIP { get; set; }
        public int SeccionalIdPorDefecto { get; set; }
        public string? SeccionalDescripcionPorDefecto { get; set; }
    }
}
