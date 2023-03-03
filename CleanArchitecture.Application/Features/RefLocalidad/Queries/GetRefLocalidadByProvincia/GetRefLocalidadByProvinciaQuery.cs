using MediatR;

namespace CleanArchitecture.Application.Features.RefLocalidad.Queries.GetRefLocalidadByProvincia
{
    public class GetRefLocalidadByProvinciaQuery : IRequest<List<RefLocalidadVm>>
    {
        public int ProvinciaId { get; set; }
    }
}
