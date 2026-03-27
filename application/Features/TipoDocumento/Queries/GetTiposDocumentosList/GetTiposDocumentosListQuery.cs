using MediatR;

namespace CleanArchitecture.Application.Features.TipoDocumento.Queries.GetTiposDocumentosList
{
    public class GetTiposDocumentosListQuery : IRequest<List<TipoDocumentoVm>>
    {
        public GetTiposDocumentosListQuery()
        {

        }
    }
}
