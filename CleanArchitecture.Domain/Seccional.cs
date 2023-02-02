using CleanArchitecture.Domain.Commom;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain
{
    public class Seccional : BaseDomainModel
    {
        [StringLength(30)]
        public string Codigo { get; set; }
        [StringLength(100)]
        public string Descripcion { get; set; }        
        public ICollection<SeccionalLocalidad> SeccionalLocalidad { get; set; }
    }
}
