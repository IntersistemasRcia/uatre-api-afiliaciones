using CleanArchitecture.Application.Features.Notificaciones.Queries.NotificacionesGet;
using CleanArchitecture.Application.Specification;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Features.Notificaciones.Queries.NotificacionesSpecs;

public class NotificacionesGetSpecs : BaseSpecification<Notificacion>
{
    public NotificacionesGetSpecs(NotificacionesGetQuery query) : base(x => 
    (string.IsNullOrEmpty(query.TipoNotificacion) || x.TipoNotificacion == query.TipoNotificacion)
    )
    {
        AgregarIncludes(x => x.Include(e => e.NotificacionesDetalle));
    }
}
