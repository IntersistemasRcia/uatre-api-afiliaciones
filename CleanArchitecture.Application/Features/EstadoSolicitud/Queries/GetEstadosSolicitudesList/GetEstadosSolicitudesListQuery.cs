using MediatR;

namespace CleanArchitecture.Application.Features.EstadoSolicitud.Queries.GetEstadosSolicitudesList
{
    public class GetEstadosSolicitudesListQuery : IRequest<List<EstadoSolicitudVm>>
    {
    }
}
