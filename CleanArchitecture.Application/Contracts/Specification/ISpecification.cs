using System.Linq.Expressions;

namespace CleanArchitecture.Application.Contracts.Specification
{
    public interface ISpecification<T>
    {
        //Filtro
        Expression<Func<T, bool>> Criteria { get; }

        //Include de tablas relacionadas
        List<Expression<Func<T, object>>> Includes { get; }

        //Ordenamiento
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDesc { get; }

        //Take
        int? TakeRecords { get; }

        //Paginacion
        int Take { get; }
        int Skip { get; }
        bool IsPagingEnabled { get; }
    }
}
