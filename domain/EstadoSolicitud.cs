using CleanArchitecture.Domain.Commom;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain
{
    public class EstadoSolicitud : EntidadAuditable
    {
        [StringLength(50)]
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
    }
}
