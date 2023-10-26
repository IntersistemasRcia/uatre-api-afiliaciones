using CleanArchitecture.Domain.Commom;

namespace CleanArchitecture.Application.Features.AfiliadoEstadoSolicitud.Queries
{
    public class AfiliadoEstadoSolicitudVm : EntidadAuditable
    {
        public string? EstadoSolicitudDescripcion { get; set; }
    }
}
