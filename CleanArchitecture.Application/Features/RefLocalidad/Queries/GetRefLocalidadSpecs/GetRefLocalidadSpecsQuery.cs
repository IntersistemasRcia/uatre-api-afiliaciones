using MediatR;

namespace CleanArchitecture.Application.Features.RefLocalidad.Queries.GetRefLocalidadSpecs
{
    public class GetRefLocalidadSpecsQuery : IRequest<List<RefLocalidadVm>>
    {
        public int? CodigoPostal { get; set; }
        public int? ProvinciaId { get;set; }
    }
}
