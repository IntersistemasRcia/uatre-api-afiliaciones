using CleanArchitecture.Domain.Commom;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain
{
    public class EstadoCivil : EntidadAuditable
    {
        [StringLength(50)]
        public string? Descripcion { get; set; }
    }
}
