using MediatR;

namespace CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesByProvinciaList
{
    public class GetSeccionalesByProvinciaListQuery : IRequest<List<SeccionalVm>>
    {
        public int ProvinciaId { get; set; }
        public GetSeccionalesByProvinciaListQuery()
        {
           //CP = pCP ?? throw new ArgumentNullException(nameof(pCP));
        }
    }
}
