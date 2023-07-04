using CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesListSpecs
    ;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Specification.Implements
{
    public class SeccionalSpecification : BaseSpecification<Seccional>
    {
        public SeccionalSpecification(GetSeccionalesListSpecsQuery query)
            : base(x =>
                (string.IsNullOrEmpty(query.Provincia) || x.SeccionalLocalidad.Where(sl => sl.RefLocalidad.Provincia.Nombre == query.Provincia).Any()) &&
                (string.IsNullOrEmpty(query.Localidad) || x.SeccionalLocalidad.Where(sl => sl.RefLocalidad.Nombre == query.Localidad).Any()) &&
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

