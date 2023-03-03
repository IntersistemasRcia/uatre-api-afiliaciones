using CleanArchitecture.Application.Features.RefLocalidad.Queries.GetRefLocalidadByProvincia;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Specification.Implements
{
    public class RefLocalidadSpecification : BaseSpecification<RefLocalidad>
    {
        public RefLocalidadSpecification(GetRefLocalidadByProvinciaQuery pParams)
            : base(x => x.ProvinciaId == pParams.ProvinciaId)
        {
            AgregarIncludes(r => r.Provincia);
        }

        public RefLocalidadSpecification(int pId) : base(x => x.Id == pId)
        {
            AgregarIncludes(r => r.Provincia);
        }
    }
}
