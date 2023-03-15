using CleanArchitecture.Application.Features.DDJJUatre.Queries.GetDDJJUatreByCUIL;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Specification.Implements
{
    public class DDJJUatreSpecification : BaseSpecification<DDJJUatre>
    {
        public DDJJUatreSpecification(GetDDJJUatreListBySpecsQuery query)
            : base(x => 
            (!query.CUIL.HasValue || x.CUIL == query.CUIL) &&
            (!query.CUIT.HasValue || x.CUIT == query.CUIT) &&
            (!query.Periodo.HasValue || x.Periodo == query.Periodo)
            //((!query.CUIL.HasValue && !query.CUIT.HasValue) || x.Id == 0)
            )
        {            
            //Ordenamiento
            if (!string.IsNullOrEmpty(query.Sort))
            {
                switch (query.Sort)
                {
                    case "periodo":
                        AddOrderByDescending(a => a.Periodo);
                        break;

                    default:
                        AddOrderBy(a => a.Id);
                        break;
                }
            }

            //TakeRecords
            if (query.TakeRecords.HasValue)
            {
                ApplyTakeRecords(query.TakeRecords ?? default(int));
            }            
        }

        public DDJJUatreSpecification(int pId) : base(x => x.Id == pId)
        {
        }
    }
}
