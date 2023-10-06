using MediatR;
namespace CleanArchitecture.Application.Features.SeccionalAutoridad.Queries.GetBySeccional
{
    public class GetSeccionalAutoridadesBySeccionalQuery : IRequest<IReadOnlyCollection<SeccionalAutoridadResponse>>
    {
        public int SeccionalId { get; set; }
        public bool SoloActivos { get; set; } = true;

        public GetSeccionalAutoridadesBySeccionalQuery()
        {

        }
    }
}
