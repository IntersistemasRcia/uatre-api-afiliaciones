using CleanArchitecture.Application.Models.APIComunes;
using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Commom;
using System.Text.Json.Serialization;
using CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresasDetalle.Queries;

namespace CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresas.Queries
{
    public class SolicitudAfiliacionEmpresasVm
    {
       public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public int SeccionalId { get; set; }
        public string? Seccional { get; set; }
        public string? SeccionalCodigo { get; set; }
        public int EmpresaId { get; set; }
        public double? EmpresaCUIT { get; set; }
        public string? EmpresaDescripcion { get; set; }
        public DateTime? EstadoFecha { get; set; }
        public int EstadoSolicitudId { get; set; }
        public string? Estado { get; set; }
        public string? EstadoSolicitudObservaciones { get; set; }
        public string? EstadoSolicitudUsuario { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string? DeletedBy { get; set; }
        public string? DeletedObs { get; set; }
        public ICollection<SolicitudAfiliacionEmpresasDetalleVm>? SolicitudAfiliacionEmpresasDetalle { get; set; }
       
    }
}
