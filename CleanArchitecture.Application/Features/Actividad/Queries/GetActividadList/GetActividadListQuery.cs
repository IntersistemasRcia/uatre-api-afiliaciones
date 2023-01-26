using MediatR;

namespace CleanArchitecture.Application.Features.Actividad.Queries.GetActividadList
{
    public class GetActividadListQuery : IRequest<List<ActividadVm>>
    {        
        public GetActividadListQuery()
        {
            //Id = pId ?? throw new ArgumentNullException(nameof(pId));
        }
    }
}
