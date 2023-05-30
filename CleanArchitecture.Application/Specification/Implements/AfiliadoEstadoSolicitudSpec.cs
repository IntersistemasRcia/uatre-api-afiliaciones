using CleanArchitecture.Application.Features.AfiliadoEstadoSolicitud.Queries.GetByAfiliadoId;
using CleanArchitecture.Application.Features.RefLocalidad.Queries.GetRefLocalidadSpecs;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Specification.Implements
{
    public class AfiliadoEstadoSolicitudSpec : BaseSpecification<AfiliadoEstadoSolicitud>
    {
        public AfiliadoEstadoSolicitudSpec(GetByAfiliadoIdQuery query)
            : base(x => x.AfiliadoId == query.AfiliadoId
            )
        {
            AgregarIncludes(r => r.Afiliado!);
            AgregarIncludes(r => r.EstadoSolicitud!);
        }

        public AfiliadoEstadoSolicitudSpec(int pId) : base(x => x.Id == pId)
        {
            AgregarIncludes(r => r.Afiliado!);
            AgregarIncludes(r => r.EstadoSolicitud!);
        }
    }
}
