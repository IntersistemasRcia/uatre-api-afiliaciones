using CleanArchitecture.Application.Features.RefLocalidad.Queries.GetRefLocalidadPaginationSpecs;
using CleanArchitecture.Application.Specification;
using Microsoft.EntityFrameworkCore;
namespace CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresas.Queries.GetSolicitudAfiliacionEmpresasListSpecs;

public class GetSolicitudAfiliacionEmpresasListSpecs : BaseSpecification<Domain.SolicitudAfiliacionEmpresas>
{
    public GetSolicitudAfiliacionEmpresasListSpecs(GetSolicitudAfiliacionEmpresasListSpecsQuery query)
        : base()
    {
        

        if (!string.IsNullOrEmpty(query.Sort) && (query.Sort.StartsWith('+') || query.Sort.StartsWith('-')))
        {
            var startWith = query.Sort.Substring(0, 1);
            switch (query.Sort.ToLower().Substring(1))
            {
                case "fecha":
                    if (startWith == "+")
                        AddOrderBy(x => x.Fecha);
                    else
                        AddOrderByDescending(x => x.Fecha);
                    break;
                case "id":
                    if (startWith == "+")
                        AddOrderBy(x => x.Id);
                    else
                        AddOrderByDescending(x => x.Id);
                    break;
            }
        }

        ApplyPaging(query.PageSize * (query.PageIndex - 1), query.PageSize);
    }

    public GetSolicitudAfiliacionEmpresasListSpecs(int pId) : base(x => x.Id == pId)
    {
        //AgregarIncludes(r => r.Include(e => e.Provincia!));        
    }
}
