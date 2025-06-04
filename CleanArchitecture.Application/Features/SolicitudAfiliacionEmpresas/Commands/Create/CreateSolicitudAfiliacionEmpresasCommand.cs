using CleanArchitecture.Application.Models.APIComunes;
using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Commom;
using MediatR;

namespace CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresas.Commands.Create
{
    public class CreateSolicitudAfiliacionEmpresasCommand : IRequest<CreateSolicitudAfiliacionEmpresasVm>
    {
        public DateTime? Fecha { get; set; }
        public int SeccionalId { get; set; }
        public int EmpresaId { get; set; }
        public int EstadoSolicitudId { get; set; }
        public DateTime? EstadoFecha { get; set; }
        public string? EstadoSolicitudObservaciones { get; set; }
        public string? EstadoSolicitudUsuario { get; set; }
        public ICollection<CreateSolicitudAfiliacionEmpresasDetalle>? SolicitudAfiliacionEmpresasDetalle { get; set; }

    }

    public class CreateSolicitudAfiliacionEmpresasDetalle
    {
        public int? Periodo { get; set; }
        public Int64? Total_Trabajadores { get; set; }
        public int? Total_Trab_Rurales { get; set; }
        public int? Total_Trab_NoRurales { get; set; }
        public int? Total_Trab_Rurales_Afiliados { get; set; }
        public int? Total_Trab_Rurales_NoAfiliados { get; set; }
        public int? Total_Trab_NoRurales_Afiliados { get; set; }
        public int? Total_Trab_NoRurales_NoAfiliados { get; set; }
    }
}
