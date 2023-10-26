using CleanArchitecture.Application.Features.AfiliadoEstadoSolicitud.Queries.GetByAfiliadoId;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Specification.Implements
{
    public class AfiliadoEstadoSolicitudSpec : BaseSpecification<AfiliadoEstadoSolicitud>
    {
        public AfiliadoEstadoSolicitudSpec(GetByAfiliadoIdQuery query)
            : base(x => x.AfiliadoId == query.AfiliadoId
            )
        {
            AgregarIncludes(r => r.Include(e => e.Afiliado!));
            AgregarIncludes(r => r.Include(e => e.EstadoSolicitud!));
        }

        public AfiliadoEstadoSolicitudSpec(int pId) : base(x => x.Id == pId)
        {
            AgregarIncludes(r => r.Include(e => e.Afiliado!));
            AgregarIncludes(r => r.Include(e => e.EstadoSolicitud!));
        }
    }
}
