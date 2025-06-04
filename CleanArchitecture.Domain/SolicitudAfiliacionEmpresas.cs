using CleanArchitecture.Domain.Commom;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain
{
    public class SolicitudAfiliacionEmpresas : EntidadAuditable
    {
        public DateTime? Fecha { get; set; }
        public int SeccionalId { get; set; }
        public Seccional? Seccional { get; set; }
        public int EmpresaId { get; set; }
        public int EstadoSolicitudId { get; set; }
        public EstadoSolicitud? EstadoSolicitud { get; set; }
        public DateTime? EstadoFecha { get; set; }
        public string? Estado { get; set; }
        public string? EstadoSolicitudObservaciones { get; set; }
        public string? EstadoSolicitudUsuario { get; set; }
        public ICollection<SolicitudAfiliacionEmpresasDetalle>? SolicitudAfiliacionEmpresasDetalle { get; set; }
    }
}
