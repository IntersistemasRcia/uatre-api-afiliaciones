using CleanArchitecture.Domain.Commom;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain
{
    public class Localidad : BaseDomainModel
    {
        public Localidad()
        {
            Nombre = string.Empty;
            Provincia = new Provincia();
        }
        [StringLength(100)]
        public string Nombre { get; set; }
        public int CP { get; set; }
        public int ProvinciaId { get; set; }        
        public Provincia Provincia { get; set; }
        public ICollection<SeccionalLocalidad>? SeccionalLocalidad { get; set; }
    }
}
