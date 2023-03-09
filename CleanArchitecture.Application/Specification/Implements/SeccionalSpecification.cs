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
        //: base(x => 
        //(!query.ProvinciaId.HasValue || x.SeccionalLocalidad.Where(sl => sl.RefLocalidad.ProvinciaId == query.ProvinciaId).Any()) &&
        //(!query.LocalidadId.HasValue || x.SeccionalLocalidad.Where(sl => sl.RefLocalidad.Id == query.LocalidadId).Any()) &&
        //(!query.CodigoPostal.HasValue || x.SeccionalLocalidad.Where(sl => sl.RefLocalidad.CodPostal == query.CodigoPostal).Any())
        //)
        {

        }

        public SeccionalSpecification(int pId) : base(x => x.Id == pId)
        {
        }
    }
}

