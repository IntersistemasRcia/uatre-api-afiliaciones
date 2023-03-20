using CleanArchitecture.Application.Contracts.Specification;
using CleanArchitecture.Domain.Commom;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Specification
{
    public class SpecificationEvaluator<T> where T : BaseDomainModel
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
        {
            //Filtros
            if (spec.Criteria != null)
            {
                inputQuery = inputQuery.Where(spec.Criteria);
            }

            //Ordenamiento
            if (spec.OrderBy != null)
            {
                inputQuery = inputQuery.OrderBy(spec.OrderBy);
            }

            if (spec.OrderByDesc != null)
            {
                inputQuery = inputQuery.OrderByDescending(spec.OrderByDesc);
            }

            //Paginacion opcional
            if (spec.IsPagingEnabled)
            {
                inputQuery = inputQuery.Skip(spec.Skip).Take(spec.Take);
            }

            //Includes
            inputQuery = spec.Includes.Aggregate(inputQuery, (current, include) => current.Include(include));

            //Group by
            if (spec.GroupBy != null)
            {
                inputQuery = inputQuery.GroupBy(spec.GroupBy).SelectMany(x => x);
            }

            //TakeRecords
            if (spec.TakeRecords.HasValue)
            {
                inputQuery = inputQuery.Take(spec.TakeRecords ?? default(int));
            }
            
            return inputQuery;
        }
    }
}
