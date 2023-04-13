using CleanArchitecture.Application.Features.SeccionalContacto.Queries.GetBySpecs;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Specification.Implements
{
    public class SeccionalContactoSpecification : BaseSpecification<SeccionalContacto>
    {
        public SeccionalContactoSpecification(GetSeccionalContactoBySpecsQuery query)
            : base(x =>
                (x.SeccionalId == query.SeccionalId)
            )
        {

        }

        public SeccionalContactoSpecification(int pId) : base(x => x.Id == pId)
        {
        }
    }
}
