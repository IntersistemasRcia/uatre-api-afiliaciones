using CleanArchitecture.Application.Features.DDJJUatre.Queries.GetDDJJUatreByCUIL;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Specification.Implements
{
    public class DDJJUatreSpecification : BaseSpecification<DDJJUatre>
    {
        public DDJJUatreSpecification(GetDDJJUatreByCUILListQuery pParams)
            : base(x => x.CUIL == pParams.CUIL)
        {
        }

        public DDJJUatreSpecification(int pId) : base(x => x.Id == pId)
        {
        }
    }
}
