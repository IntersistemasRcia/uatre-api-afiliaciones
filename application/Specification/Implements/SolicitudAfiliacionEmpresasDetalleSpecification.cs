using CleanArchitecture.Application.Features.SeccionalAutoridad.Queries.GetBySpecs;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Specification.Implements
{
    public class SolicitudAfiliacionEmpresasDetalleSpecification(int pSolicitudEmpresaId) : BaseSpecification<SolicitudAfiliacionEmpresasDetalle>(x =>
                (x.SolicitudAfiliacionEmpresasId == pSolicitudEmpresaId) &&
                (x.DeletedDate == null)
            )
    {

    }
}
