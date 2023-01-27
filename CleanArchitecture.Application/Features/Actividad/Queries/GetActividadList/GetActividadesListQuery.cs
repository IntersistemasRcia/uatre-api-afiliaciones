using MediatR;

namespace CleanArchitecture.Application.Features.Actividad.Queries.GetActividadList
{
    public class GetActividadesListQuery : IRequest<List<ActividadVm>>
    {        
        public GetActividadesListQuery()
        {
            //Id = pId ?? throw new ArgumentNullException(nameof(pId));
        }
    }
}
