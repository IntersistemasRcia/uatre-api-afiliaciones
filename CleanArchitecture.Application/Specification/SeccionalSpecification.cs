using CleanArchitecture.Application.Features.Afiliado.Queries.GetAfiliadoList;
using CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesByCPList;
using CleanArchitecture.Domain;
using System.Security.Cryptography.X509Certificates;

namespace CleanArchitecture.Application.Specification
{
    public class SeccionalSpecification : BaseSpecification<Seccional>
    {
        public SeccionalSpecification(GetSeccionalesByCPListQuery pParams)
            : base(x => x.SeccionalLocalidad.Where(sl => sl.Localidad.CP == pParams.CP).Any())
        {
            
        }

        public SeccionalSpecification(int pId) : base(x => x.Id == pId)
        {           
        }
    }
}

