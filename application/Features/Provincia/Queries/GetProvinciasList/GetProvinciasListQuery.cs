using MediatR;

namespace CleanArchitecture.Application.Features.Provincia.Queries.GetProvinciasList
{
    public class GetProvinciasListQuery : IRequest<List<ProvinciaVm>>
    {        
        public GetProvinciasListQuery()
        {
            //Id = pId ?? throw new ArgumentNullException(nameof(pId));
        }
    }
}
