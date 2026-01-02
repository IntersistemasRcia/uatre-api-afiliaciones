using CleanArchitecture.Application.Specification;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Features.SeccionalLocalidad.Queries.GetSeccionalLocalidadByRefLocalidadId;

public class GetSeccionalLocalidadByRefLocalidadIdSpec : BaseSpecification<Domain.SeccionalLocalidad>
{
    public GetSeccionalLocalidadByRefLocalidadIdSpec(GetSeccionalLocalidadByRefLocalidadIdCommand query) : base(x => 
    (x.RefLocalidadId == query.RefLocalidadId) &&
    (!query.SoloActivos || x.DeletedDate == null)
    )
    {
        AgregarIncludes(x => x.Include(e => e.RefLocalidad));
        AgregarIncludes(x => x.Include(e => e.Seccional));
    }
}
