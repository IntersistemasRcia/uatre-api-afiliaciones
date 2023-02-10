using CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesByProvinciaList;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Specification
{
    public class SeccionalSpecification : BaseSpecification<Seccional>
    {
        public SeccionalSpecification(GetSeccionalesByProvinciaListQuery pParams)
            : base(x => x.SeccionalLocalidad.Where(sl => sl.Localidad.ProvinciaId == pParams.ProvinciaId).Any())
        {
            
        }

        public SeccionalSpecification(int pId) : base(x => x.Id == pId)
        {           
        }
    }
}

