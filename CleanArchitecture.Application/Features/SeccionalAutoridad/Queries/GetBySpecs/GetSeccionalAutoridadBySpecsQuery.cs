using MediatR;

namespace CleanArchitecture.Application.Features.SeccionalAutoridad.Queries.GetBySpecs
{
    public class GetSeccionalAutoridadBySpecsQuery : IRequest<List<SeccionalAutoridadResponse>>
    {
        public int? SeccionalId { get; set; }
        public bool SoloActivos { get; set; } = true;
        public bool SoloVigentes { get; set; } = true;
        public GetSeccionalAutoridadBySpecsQuery()
        {
        }
    }
}
