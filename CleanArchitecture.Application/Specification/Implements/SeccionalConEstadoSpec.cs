using CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesListSpecs;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Specification.Implements;

public class SeccionalConEstadoSpec : BaseSpecification<Domain.Seccional>
{
    public SeccionalConEstadoSpec(Ambito ambito, List<string> estadosActiva) : base(x => ambito.Ids.Contains(x.Id)
    && estadosActiva.Contains(x.SeccionalEstado.Descripcion))
    {
        AgregarIncludes(x => x.Include(e => e.SeccionalEstado!));        
    }    
}
