using CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesListSpecs;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Specification.Implements;

public class SeccionalesDelegacionSpec : BaseSpecification<Domain.Seccional>
{
    public SeccionalesDelegacionSpec(Ambito ambito, List<string> estadosActiva) : base(x => ambito.Ids.Contains(x.RefDelegacionId)
    && estadosActiva.Contains(x.SeccionalEstado.Descripcion))
    {
        AgregarIncludes(x => x.Include(e => e.SeccionalEstado!));
    }
}
