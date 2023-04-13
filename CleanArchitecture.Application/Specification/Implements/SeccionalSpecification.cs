using CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesListSpecs
    ;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Specification.Implements
{
    public class SeccionalSpecification : BaseSpecification<Seccional>
    {
        public SeccionalSpecification(GetSeccionalesListSpecsQuery query)
            : base(x =>
                (!query.ProvinciaId.HasValue || x.SeccionalLocalidad.Where(sl => sl.RefLocalidad.ProvinciaId == query.ProvinciaId).Any()) &&
                (!query.LocalidadId.HasValue || x.SeccionalLocalidad.Where(sl => sl.RefLocalidad.Id == query.LocalidadId).Any()) &&
                (!query.CodigoPostal.HasValue || x.SeccionalLocalidad.Where(sl => sl.RefLocalidad.CodPostal == query.CodigoPostal).Any())
            )
        {
            AgregarIncludes(x => x.SeccionalContacto);
            AgregarIncludes(x => x.SeccionalAutoridad);
        }

        public SeccionalSpecification(int pId) : base(x => x.Id == pId)
        {
            AgregarIncludes(x => x.SeccionalContacto);
            AgregarIncludes(x => x.SeccionalAutoridad);
        }
    }
}

