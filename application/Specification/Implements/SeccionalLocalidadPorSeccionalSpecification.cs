using CleanArchitecture.Application.Features.SeccionalAutoridad.Queries.GetBySpecs;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Specification.Implements
{
    public class SeccionalLocalidadPorSeccionalSpecification(int pSeccionalId, bool? activos = null) : BaseSpecification<SeccionalLocalidad>(x =>
                (x.SeccionalId == pSeccionalId) &&
                (activos == null || ( (activos == true) ?
                x.DeletedDate == null : x.DeletedDate != null))
            )
    {

        /*public SeccionalLocalidadPorSeccionalSpecification(int pSeccionalId) : base(x => x.Id == pSeccionalId)
        {
        }
        */
    }
}
