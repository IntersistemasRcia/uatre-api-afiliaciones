using CleanArchitecture.Application.Features.SeccionalAutoridad.Queries.GetBySpecs;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Specification.Implements
{
    public class SeccionalAutoridadSpecification : BaseSpecification<SeccionalAutoridad>
    {
        public SeccionalAutoridadSpecification(GetSeccionalAutoridadBySpecsQuery query)
            : base(x =>
                (x.SeccionalId == query.SeccionalId)  &&
                (!query.SoloActivos || x.DeletedDate == null) &&
                (!query.SoloVigentes || x.FechaVigenciaDesde <= DateTime.Now.Date && x.FechaVigenciaHasta >= DateTime.Now.Date)
            )
        {

        }

        public SeccionalAutoridadSpecification(int pId) : base(x => x.Id == pId)
        {
        }
    }
}
