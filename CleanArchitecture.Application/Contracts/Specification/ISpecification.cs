using CleanArchitecture.Application.Specification;
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
        List<OrderDetails> Order { get; set; }
        List<Expression<Func<T, object>>> OrderBy { get; }
        List<Expression<Func<T, object>>> OrderByDesc { get; }        

        //Agrupar
        Expression<Func<T, object>> GroupBy { get; }

        //Take
        int? TakeRecords { get; }

        //Paginacion
        int Take { get; }
        int Skip { get; }
        bool IsPagingEnabled { get; }

        public class OrderDetails
        {
            public Expression<Func<T, object>> Order { get; set; }
            public bool descending { get; set; }
        }
    }
}
