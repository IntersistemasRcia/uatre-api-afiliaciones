using CleanArchitecture.Domain.Commom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain
{
    public class Localidad : BaseDomainModel
    {
        [StringLength(100)]
        public string Nombre { get; set; }
        public int ProvinciaId { get; set; }
        public Provincia Provincia { get; set; }
        public ICollection<SeccionalLocalidad> SeccionalLocalidad { get; set; }
    }
}
