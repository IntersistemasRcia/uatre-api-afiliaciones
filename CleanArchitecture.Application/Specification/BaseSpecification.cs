using CleanArchitecture.Application.Contracts.Specification;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace CleanArchitecture.Application.Specification
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification() { }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; private set; }
        protected void SetCriteria(Expression<Func<T, bool>> criteria)
        { 
            Criteria = criteria; 
        }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        protected void AgregarIncludes(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        public Expression<Func<T, object>> OrderBy { get; private set; }
        public Expression<Func<T, object>> OrderByDesc { get; private set; }
        public Expression<Func<T, object>> GroupBy { get; private set; }

        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDesc = orderByDescExpression;
        }

        protected void ApplyGroupBy(Expression<Func<T, object>> groupByExpression)
        {
            GroupBy = groupByExpression;
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

        //Implementacion Takerecords
        public int? TakeRecords { get; private set; }
        protected void ApplyTakeRecords(int takeRecords)
        {
            TakeRecords = takeRecords;
        }
    }
}
