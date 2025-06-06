using CleanArchitecture.Application.Specification;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresasDetalle.Queries.GetByEmpresaId;

public class GetByEmpresaIdSpec : BaseSpecification<Domain.SolicitudAfiliacionEmpresasDetalle>
{
    public GetByEmpresaIdSpec(GetByEmpresaIdCommand query) : base(x => 
    (x.SolicitudAfiliacionEmpresasId == query.SolicitudAfiliacionEmpresasId) &&
    (x.DeletedDate == null)
    )
    {
        //AgregarIncludes(x => x.Include(e => e.));
        //AgregarIncludes(x => x.Include(e => e.Seccional));
    }
}
