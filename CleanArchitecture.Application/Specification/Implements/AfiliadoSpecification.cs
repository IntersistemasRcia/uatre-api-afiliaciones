using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Features.Afiliado.Queries.GetAfiliadoList;
using CleanArchitecture.Domain;
using Newtonsoft.Json.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CleanArchitecture.Application.Specification.Implements
{
    public class AfiliadoSpecification : BaseSpecification<Afiliado>
    {
        public AfiliadoSpecification(GetAfiliadoListQuery pParams)
            : base()
        {
            if (!string.IsNullOrEmpty(pParams.FilterValue) && !string.IsNullOrEmpty(pParams.FilterBy))
            {
                var specificationType = GetType().BaseType;
                var targetType = specificationType.GenericTypeArguments[0];
                var propertyName = pParams.FilterBy;
                var property = targetType.GetRuntimeProperty(propertyName) ??
                               throw new BadRequestException($"El campo {propertyName} no existe.");

                var lambdaParamX = Expression.Parameter(targetType, "x");
                var left = Expression.Property(lambdaParamX, pParams.FilterBy);

                switch (property.PropertyType.ToString())
                {
                    case "System.Int32":
                        int value = 0;
                        if (int.TryParse(pParams.FilterValue, out value) == false)
                        {
                            throw new BadRequestException($"El tipo de dato para el campo {propertyName} no coincide.");
                        }
                        var rightInt32 = Expression.Constant(value, typeof(int));
                        var bodyInt32 = Expression.Equal(left, rightInt32);

                        SetCriteria(Expression.Lambda<Func<Afiliado, bool>>(bodyInt32, lambdaParamX));
                        break;

                    case "System.Int64":
                        Int64 valueInt64 = 0;
                        if (!Int64.TryParse(pParams.FilterValue, out valueInt64))
                        {
                            throw new BadRequestException($"El tipo de dato para el campo {propertyName} no coincide.");
                        }
                        var rightInt64 = Expression.Constant(valueInt64, typeof(Int64));
                        var bodyInt64 = Expression.Equal(left, rightInt64);

                        SetCriteria(Expression.Lambda<Func<Afiliado, bool>>(bodyInt64, lambdaParamX));
                        break;

                    case "System.String":
                        MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) })!;
                        var rightString = Expression.Constant(pParams.FilterValue, typeof(string));
                        //var bodyString = Expression.Equal(left, rightString);
                        var bodyString = Expression.Call(left, method!, rightString);

                        SetCriteria(Expression.Lambda<Func<Afiliado, bool>>(bodyString, lambdaParamX));
                        break;

                    case "System.DateTime":
                        DateTime date = new DateTime();
                        if (!DateTime.TryParse(pParams.FilterValue, out date))
                        {
                            throw new BadRequestException($"El valor para el campo {propertyName} no es de tipo DateTime.");
                        }                        
                        var rightDate = Expression.Constant(date, typeof(DateTime));
                        var bodyDate = Expression.Equal(left, rightDate);

                        SetCriteria(Expression.Lambda<Func<Afiliado, bool>>(bodyDate, lambdaParamX));
                        break;

                    default:
                        throw new BadRequestException($"El tipo de dato para el campo {propertyName} no está mapeado.");
                }                
            }

            //Agrego tablas relacionadas
            AgregarIncludes(a => a.EstadoSolicitud!);
            AgregarIncludes(a => a.Seccional!);
            AgregarIncludes(a => a.Sexo!);
            AgregarIncludes(a => a.Actividad!);
            AgregarIncludes(a => a.Puesto!);
            AgregarIncludes(a => a.RefLocalidad!);
            AgregarIncludes(a => a.RefLocalidad!.Provincia!);
            AgregarIncludes(a => a.Empresa!);
            AgregarIncludes(a => a.Nacionalidad!);
            AgregarIncludes(a => a.EstadoCivil!);
            AgregarIncludes(a => a.TipoDocumento!);

            //Paginacion
            ApplyPaging(pParams.PageSize * (pParams.PageIndex - 1), pParams.PageSize);

            //Ordenamiento            
            if (!string.IsNullOrEmpty(pParams.Sort))
            {
                const string descendingSuffix = "Desc";

                var descending = pParams.Sort.EndsWith(descendingSuffix, StringComparison.Ordinal);
                var propertyName = pParams.Sort.Substring(0, 1).ToUpperInvariant() +
                                   pParams.Sort.Substring(1, pParams.Sort.Length - 1 - (descending ? descendingSuffix.Length : 0));

                var specificationType = GetType().BaseType;
                var targetType = specificationType.GenericTypeArguments[0];
                var property = targetType.GetRuntimeProperty(propertyName) ??
                               throw new BadRequestException($"El campo {propertyName} no existe.");

                // Create an Expression<Func<T, object>>.
                var lambdaParamX = Expression.Parameter(targetType, "x");

                var propertyReturningExpression = Expression.Lambda(
                    Expression.Convert(
                        Expression.Property(lambdaParamX, property),
                        typeof(object)),
                    lambdaParamX);

                if (descending)
                {
                    specificationType.GetMethod(
                            nameof(AddOrderByDescending),
                            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)!
                        .Invoke(this, new object[] { propertyReturningExpression });
                }
                else
                {
                    specificationType.GetMethod(
                            nameof(AddOrderBy),
                            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)!
                        .Invoke(this, new object[] { propertyReturningExpression });
                }
            }
        }

        public AfiliadoSpecification(int pId) : base(x => x.Id == pId)
        {
            //Agrego tablas relacionadas
            AgregarIncludes(a => a.EstadoSolicitud!);
            AgregarIncludes(a => a.Seccional!);
            AgregarIncludes(a => a.Sexo!);
            AgregarIncludes(a => a.Actividad!);
            AgregarIncludes(a => a.Puesto!);
            AgregarIncludes(a => a.RefLocalidad!);
            AgregarIncludes(a => a.RefLocalidad!.Provincia!);
            AgregarIncludes(a => a.Empresa!);
            AgregarIncludes(a => a.Nacionalidad!);
            AgregarIncludes(a => a.EstadoCivil!);
            AgregarIncludes(a => a.TipoDocumento!);
        }

        
    }
}
