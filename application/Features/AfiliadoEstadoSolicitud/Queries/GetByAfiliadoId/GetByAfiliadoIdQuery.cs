using MediatR;

namespace CleanArchitecture.Application.Features.AfiliadoEstadoSolicitud.Queries.GetByAfiliadoId
{
    public class GetByAfiliadoIdQuery : IRequest<List<AfiliadoEstadoSolicitudVm>>
    {
        public int AfiliadoId { get; private set; }
        public string? Sort { get; set; }

        public GetByAfiliadoIdQuery(int afiliadoId, string sort)
        {
            AfiliadoId = afiliadoId;
            Sort = sort;
        }
    }
}
