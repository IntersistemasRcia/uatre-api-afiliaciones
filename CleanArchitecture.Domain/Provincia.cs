using CleanArchitecture.Domain.Commom;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain
{
    public class Provincia : BaseDomainModel
    {
        public Provincia()
        {
            Nombre = string.Empty;
        }
        [StringLength(50)]
        public string Nombre { get; set; }
        public int IdProvinciaAFIP { get; set; }
    }
}
