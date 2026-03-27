using MediatR;

namespace CleanArchitecture.Application.Features.EstadoCivil.Queries.GetEstadoCivilList
{
    public class GetEstadoCivilListQuery : IRequest<List<EstadoCivilVm>>
    {
        public bool SoloActivos { get; set; } = true;
        public GetEstadoCivilListQuery()
        {

        }
    }
}
