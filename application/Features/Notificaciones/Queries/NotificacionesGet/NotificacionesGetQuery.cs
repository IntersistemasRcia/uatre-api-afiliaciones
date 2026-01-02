using MediatR;

namespace CleanArchitecture.Application.Features.Notificaciones.Queries.NotificacionesGet;

public class NotificacionesGetQuery : IRequest<IReadOnlyList<NotificacionesResponse>>
{
    public string? TipoNotificacion { get; set; }
}
