using CleanArchitecture.Application.Features.SeccionalAutoridad.Queries;
using MediatR;

namespace CleanArchitecture.Application.Features.SeccionalContacto.Queries.GetById
{
    public class GetSeccionalContactoByIdQuery : IRequest<SeccionalContactoResponse>
    {
        public int Id { get; set; }

        public GetSeccionalContactoByIdQuery()
        {
        }
    }
}
