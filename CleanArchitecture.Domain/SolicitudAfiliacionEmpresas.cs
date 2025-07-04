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
        public string? EstadoSolicitudObservaciones { get; set; }
        public string? EstadoSolicitudUsuario { get; set; }
        public int? Periodo { get; set; }
        public Int64? Total_Trabajadores { get; set; }
        public int? Total_Trab_Rurales { get; set; }
        public int? Total_Trab_NoRurales { get; set; }
        public int? Total_Trab_Rurales_Afiliados { get; set; }
        public int? Total_Trab_Rurales_NoAfiliados { get; set; }
        public int? Total_Trab_NoRurales_Afiliados { get; set; }
        public int? Total_Trab_NoRurales_NoAfiliados { get; set; }
        public ICollection<SolicitudAfiliacionEmpresasDetalle>? SolicitudAfiliacionEmpresasDetalle { get; set; }
    }
}
