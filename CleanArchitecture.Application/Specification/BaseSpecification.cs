using CleanArchitecture.Application.Contracts.Specification;
using CleanArchitecture.Common.Exceptions;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using System.Reflection;
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

        //public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
        public List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> Includes { get; } = new List<Func<IQueryable<T>, IIncludableQueryable<T, object>>>();

        protected void AgregarIncludes(Func<IQueryable<T>, IIncludableQueryable<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        public List<ISpecification<T>.OrderDetails> Order { get; set; } = new();
        public List<Expression<Func<T, object>>> OrderBy { get; private set; } = new List<Expression<Func<T, object>>>();
        public List<Expression<Func<T, object>>> OrderByDesc { get; private set; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> GroupBy { get; private set; }

        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy.Add(orderByExpression);
        }

        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDesc.Add(orderByDescExpression);
        }

        protected void AddOrder(string sortExpression)
        {
            const string descendingSuffix = "Desc";
            var OrderDetails = sortExpression.Split(",");
            foreach (var order in OrderDetails)
            {
                var descending = order.EndsWith(descendingSuffix, StringComparison.Ordinal);
                var propertyName = order.Substring(0, 1).ToUpperInvariant() +
                                    order.Substring(1, order.Length - 1 - (descending ? descendingSuffix.Length : 0));

                var specificationType = GetType().BaseType;
                var targetType = specificationType.GenericTypeArguments[0];
                var property = targetType.GetRuntimeProperty(propertyName) ??
                                throw new BadRequestException($"El campo {propertyName} no existe.");


                //Create an Expression<Func<T, object>>.
                var lambdaParamX = Expression.Parameter(targetType, "x");

                var propertyReturningExpression = Expression.Lambda(
                    Expression.Convert(
                        Expression.Property(lambdaParamX, property),
                        typeof(object)),
                    lambdaParamX);
                
                ISpecification<T>.OrderDetails item = new() { Order = (Expression<Func<T, object>>)propertyReturningExpression, descending = descending };
                Order.Add(item);
            }
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
