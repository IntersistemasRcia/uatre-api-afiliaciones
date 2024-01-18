using CleanArchitecture.Application.Specification;
using Microsoft.EntityFrameworkCore;
namespace CleanArchitecture.Application.Features.RefLocalidad.Queries.GetRefLocalidadPaginationSpecs;

public class GetRefLocalidadPaginationSpecs : BaseSpecification<Domain.RefLocalidad>
{
    public GetRefLocalidadPaginationSpecs(GetRefLocalidadPaginationSpecsQuery query)
        : base()
    {
        AgregarIncludes(r => r.Include(e => e.Provincia!));
        AgregarIncludes(r => r.Include(e => e.SeccionalLocalidad!));

        SetCriteria(x => (!query.ProvinciaId.HasValue || x.ProvinciaId == query.ProvinciaId) &&
        (string.IsNullOrEmpty(query.FilterByCPNombre) || (x.Nombre.Contains(query.FilterByCPNombre) || x.CodPostal.ToString().Contains(query.FilterByCPNombre))) &&
        (!query.Bajas.HasValue || (query.Bajas == true ? x.DeletedDate != null : x.DeletedDate == null))
        );

        if (!string.IsNullOrEmpty(query.SortBy) && (query.SortBy.StartsWith('+') || query.SortBy.StartsWith('-')))
        {
            var startWith = query.SortBy.Substring(0, 1);
            switch (query.SortBy.Substring(1))
            {
                case "nombre":
                    if (startWith == "+")
                        AddOrderBy(x => x.Nombre);
                    else
                        AddOrderByDescending(x => x.Nombre);
                    break;

                case "codpostal":
                    if (startWith == "+")
                        AddOrderBy(x => x.CodPostal);
                    else
                        AddOrderByDescending(x => x.CodPostal);
                    break;
            }
        }

        ApplyPaging(query.PageSize * (query.PageIndex - 1), query.PageSize);
    }

    public GetRefLocalidadPaginationSpecs(int pId) : base(x => x.Id == pId)
    {
        AgregarIncludes(r => r.Include(e => e.Provincia!));        
    }
}
