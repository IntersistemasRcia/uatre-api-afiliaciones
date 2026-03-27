using CleanArchitecture.Domain.Commom;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain
{
    public class SeccionalAutoridad : EntidadAuditable
    {
        public int SeccionalId { get; set; }
        public Seccional? Seccional { get; set; }
        public int AfiliadoId { get; set; }
        public int RefCargosId { get; set; }        
        public string? Observaciones { get; set; }
        public DateTime? FechaVigenciaDesde  { get; set; }
        public DateTime? FechaVigenciaHasta { get; set; }
        [NotMapped]
        public string? RefCargosDescripcion { get; set; }
        [NotMapped]
        public int RefCargosJerarquia { get; set; }
        [NotMapped]
        public string? AfiliadoNombre { get; set; }
        [NotMapped]
        public int AfiliadoNumero { get; set; }
    }
}
