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

            if (!string.IsNullOrEmpty(query.Sort))
            {
                var startsWith = query.Sort.Substring(0, 1);
                var sortBy = query.Sort.Substring(1).ToLower();

                switch (sortBy)
                {
                    case "createddate":
                        if (startsWith == "-")
                        {
                            AddOrderByDescending(x => x.CreatedDate);
                        }
                        else
                        {
                            AddOrderBy(x => x.CreatedDate);
                        }
                        break;

                    default:
                        break;
                }                
            }            
        }

        public AfiliadoEstadoSolicitudSpec(int pId) : base(x => x.Id == pId)
        {
            AgregarIncludes(r => r.Include(e => e.Afiliado!));
            AgregarIncludes(r => r.Include(e => e.EstadoSolicitud!));
        }
    }
}
