using MediatR;

namespace CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesList
{
    public class GetSeccionalesListQuery : IRequest<List<SeccionalVm>>
    {
        public bool? SoloActivos { get; set; } = true;
        public int? LocalidadId { get; set; }
        public int? ProvinciaId { get; set; }
        public GetSeccionalesListQuery()
        {
            //Id = pId ?? throw new ArgumentNullException(nameof(pId));
        }
    }
}
