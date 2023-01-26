using MediatR;

namespace CleanArchitecture.Application.Features.Sexo.Queries.GetSexoList
{
    public class GetSexoListQuery : IRequest<List<SexoVm>>
    {        
        public GetSexoListQuery()
        {
            //Id = pId ?? throw new ArgumentNullException(nameof(pId));
        }
    }
}
