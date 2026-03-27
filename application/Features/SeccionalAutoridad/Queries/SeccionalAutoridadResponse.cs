
using CleanArchitecture.Domain.Commom;

namespace CleanArchitecture.Application.Features.SeccionalAutoridad.Queries
{
    public class SeccionalAutoridadResponse : EntidadAuditable
    {
        public int SeccionalId { get; set; }
        public string? SeccionalDescripcion { get; set; }
        public int AfiliadoId { get; set; }
        public int RefCargosId { get; set; }
        public string? Observaciones { get; set; }
        public DateTime? FechaVigenciaDesde { get; set; }
        public DateTime? FechaVigenciaHasta { get; set; }
        public string? RefCargosDescripcion { get; set; }
        public int RefCargoJerarquia { get; set; }
        public string? AfiliadoNombre { get; set; }
        public int AfiliadoNumero { get; set; }
    }
}
