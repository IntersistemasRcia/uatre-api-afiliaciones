using MediatR;

namespace CleanArchitecture.Application.Features.AfiliadoEstadoSolicitud.Queries.GetByAfiliadoId
{
    public class GetByAfiliadoIdQuery : IRequest<List<AfiliadoEstadoSolicitudVm>>
    {
        public int AfiliadoId { get; set; }
        public GetByAfiliadoIdQuery()
        {
            
        }
    }
}
