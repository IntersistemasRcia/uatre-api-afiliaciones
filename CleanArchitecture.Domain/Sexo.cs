using CleanArchitecture.Domain.Commom;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain
{
    public class Sexo : EntidadAuditable
    {
        [StringLength(3)]
        public string Codigo { get; set; }
        [StringLength(50)]
        public string Descripcion { get; set; }
    }
}
