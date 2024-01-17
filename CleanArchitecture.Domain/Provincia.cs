using CleanArchitecture.Domain.Commom;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain
{
    public class Provincia : EntidadAuditable
    {
        public Provincia()
        {
            Nombre = string.Empty;
            Seccional = new Seccional();
        }

        [StringLength(50)]
        public string Nombre { get; set; }
        public int IdProvinciaAFIP { get; set; }
        public int SeccionalIdPorDefecto { get; set; }
        public Seccional Seccional { get; set; }
        public int LocalidadIdPorDefecto { get; set; }
    }
}
