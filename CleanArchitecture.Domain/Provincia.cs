using CleanArchitecture.Domain.Commom;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain
{
    public class Provincia : BaseDomainModel
    {
        [StringLength(50)]
        public string Nombre { get; set; }

    }
}
