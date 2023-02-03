using MediatR;

namespace CleanArchitecture.Application.Features.Provincia.Queries.GetNacionalidadesList
{
    public class GetNacionalidadesListQuery : IRequest<List<NacionalidadVm>>
    {        
        public GetNacionalidadesListQuery()
        {
            //Id = pId ?? throw new ArgumentNullException(nameof(pId));
        }
    }
}
