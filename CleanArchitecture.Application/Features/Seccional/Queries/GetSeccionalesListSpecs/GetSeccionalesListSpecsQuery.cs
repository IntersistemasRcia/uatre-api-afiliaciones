using MediatR;

namespace CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesListSpecs
{
    public class GetSeccionalesListSpecsQuery : IRequest<List<SeccionalVm>>
    {
        public string? Provincia { get; set; }
        public int? ProvinciaId { get; set; }
        public string? Localidad { get; set; }
        public int? LocalidadId { get; set; }
        public int? CodigoPostal { get; set; }
        public bool SoloActivos { get; set; } = true;
        public GetSeccionalesListSpecsQuery()
        {
           //CP = pCP ?? throw new ArgumentNullException(nameof(pCP));
        }
    }
}
