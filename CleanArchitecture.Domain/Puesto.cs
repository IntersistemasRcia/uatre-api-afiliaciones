using CleanArchitecture.Domain.Commom;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain
{
    public class Puesto : BaseDomainModel
    {
        [StringLength(100)]
        public string Descripcion { get; set; }
    }
}
