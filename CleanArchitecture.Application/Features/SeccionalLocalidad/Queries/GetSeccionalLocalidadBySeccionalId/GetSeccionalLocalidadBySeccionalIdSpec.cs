using CleanArchitecture.Application.Specification;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Features.SeccionalLocalidad.Queries.GetSeccionalLocalidadBySeccionalId;

public class GetSeccionalLocalidadBySeccionalIdSpec : BaseSpecification<Domain.SeccionalLocalidad>
{
    public GetSeccionalLocalidadBySeccionalIdSpec(GetSeccionalLocalidadBySeccionalIdCommand query) : base(x => 
    (x.SeccionalId == query.SeccionalId) &&
    (!query.SoloActivos || x.DeletedDate == null)
    )
    {
        AgregarIncludes(x => x.Include(e => e.RefLocalidad));
    }
}
