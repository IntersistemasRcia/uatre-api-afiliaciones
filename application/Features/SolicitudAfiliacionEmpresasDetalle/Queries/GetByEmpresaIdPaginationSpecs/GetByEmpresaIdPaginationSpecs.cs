using CleanArchitecture.Application.Features.RefLocalidad.Queries.GetRefLocalidadPaginationSpecs;
using CleanArchitecture.Application.Specification;
using Microsoft.EntityFrameworkCore;
namespace CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresasDetalle.Queries.GetByEmpresaIdPaginationSpecs;

public class GetByEmpresaIdPaginationSpecs : BaseSpecification<Domain.SolicitudAfiliacionEmpresasDetalle>
{
    public GetByEmpresaIdPaginationSpecs(GetByEmpresaIdPaginationSpecsQuery query)
        : base()
    {
        

        SetCriteria(x => (!query.SolicitudAfiliacionEmpresasId.HasValue || x.SolicitudAfiliacionEmpresasId == query.SolicitudAfiliacionEmpresasId)
        );

        if (!string.IsNullOrEmpty(query.SortBy) && (query.SortBy.StartsWith('+') || query.SortBy.StartsWith('-')))
        {
            var startWith = query.SortBy.Substring(0, 1);
            switch (query.SortBy.ToLower().Substring(1))
            {
                case "periodo":
                    if (startWith == "+")
                        AddOrderBy(x => x.Periodo);
                    else
                        AddOrderByDescending(x => x.Periodo);
                    break;
            }
        }

        ApplyPaging(query.PageSize * (query.PageIndex - 1), query.PageSize);
    }

    public GetByEmpresaIdPaginationSpecs(int pId) : base(x => x.Id == pId)
    {
        //AgregarIncludes(r => r.Include(e => e.Provincia!));        
    }
}
