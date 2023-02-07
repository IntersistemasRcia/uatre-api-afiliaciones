using MediatR;

namespace CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesByCPList
{
    public class GetSeccionalesByCPListQuery : IRequest<List<SeccionalVm>>
    {
        public int CP { get; set; }
        public GetSeccionalesByCPListQuery()
        {
           //CP = pCP ?? throw new ArgumentNullException(nameof(pCP));
        }
    }
}
