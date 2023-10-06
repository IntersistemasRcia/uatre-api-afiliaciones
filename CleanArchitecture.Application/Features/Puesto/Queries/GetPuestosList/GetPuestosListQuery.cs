using MediatR;

namespace CleanArchitecture.Application.Features.Puesto.Queries.GetPuestosList
{
    public class GetPuestosListQuery : IRequest<List<PuestoVm>>
    {
        public bool SoloActivos { get; set; } = true;
        public GetPuestosListQuery()
        {
            //Id = pId ?? throw new ArgumentNullException(nameof(pId));
        }
    }
}
