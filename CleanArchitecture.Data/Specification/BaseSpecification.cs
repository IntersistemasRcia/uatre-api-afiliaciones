using CleanArchitecture.Application.Contracts.Specification;
using System.Linq.Expressions;

namespace CleanArchitecture.Infrastructure.Specification
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        /// <summary>
        /// Implementación de la interfaz ISpecification
        /// </summary>
        public BaseSpecification() { }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        protected void AgregarIncludes(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }


        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDesc { get; private set; }


        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderBy = orderByDescExpression;
        }


        //Implementación de paginación
        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagingEnabled { get; private set; }

        protected void ApplyPaging(int pSkip, int pTake)
        {
            Take = pTake;
            Skip = pSkip;
            IsPagingEnabled = true;
        }
    }
}
