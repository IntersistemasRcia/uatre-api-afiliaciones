using CleanArchitecture.Application.Contracts.Specification;
using CleanArchitecture.Domain.Commom;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
            IOrderedQueryable<T>? orderedQuery = null;            
            if (spec.Order != null)
            {
                var count = spec.Order.Count;

                for (int i = 0; i < count; ++i)
                {
                    if (i == 0)
                    {
                        orderedQuery = spec.Order[i].descending ? inputQuery.OrderByDescending(spec.Order[i].Order) : inputQuery.OrderBy(spec.Order[i].Order);
                    }
                    else
                    {
                        orderedQuery = spec.Order[i].descending ? orderedQuery!.ThenByDescending(spec.Order[i].Order) : orderedQuery!.ThenBy(spec.Order[i].Order);
                    }
                    Console.WriteLine(spec.Order[i]);
                }
                inputQuery = orderedQuery ?? inputQuery;
            }            

            //Paginacion opcional
            if (spec.IsPagingEnabled)
            {
                inputQuery = inputQuery.Skip(spec.Skip).Take(spec.Take);
            }

            //Includes
            inputQuery = spec.Includes.Aggregate(inputQuery,
                                    (current, include) => include(current));

            //// Include any string-based include statements
            //inputQuery = spec.IncludeStrings.Aggregate(inputQuery,
            //                        (current, include) => current.Include(include));

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
