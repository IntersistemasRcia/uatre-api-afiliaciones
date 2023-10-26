using CleanArchitecture.Domain.Commom;

namespace CleanArchitecture.Application.Features.EstadoSolicitud.Queries
{
    public class EstadoSolicitudVm : EntidadAuditable
    {
        public string? Descripcion { get; set; }
    }
}
