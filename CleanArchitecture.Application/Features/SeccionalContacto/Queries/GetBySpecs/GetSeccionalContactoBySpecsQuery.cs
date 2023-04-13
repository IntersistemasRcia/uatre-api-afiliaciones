using MediatR;

namespace CleanArchitecture.Application.Features.SeccionalContacto.Queries.GetBySpecs
{
    public class GetSeccionalContactoBySpecsQuery : IRequest<List<SeccionalContactoResponse>>
    {
        public int? SeccionalId { get; set; }
        public GetSeccionalContactoBySpecsQuery()
        {
        }
    }
}
