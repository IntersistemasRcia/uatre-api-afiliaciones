using MediatR;

namespace CleanArchitecture.Application.Features.SeccionalAutoridad.Queries.GetById
{
    public class GetSeccionalAutoridadByIdQuery : IRequest<SeccionalAutoridadResponse>
    {
        public int Id { get; set; }

        public GetSeccionalAutoridadByIdQuery()
        {            
        }    
    }
}
