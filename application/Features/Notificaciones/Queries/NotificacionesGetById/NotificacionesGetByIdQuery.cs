using MediatR;

namespace CleanArchitecture.Application.Features.Notificaciones.Queries.NotificacionesGetById;

public class NotificacionesGetByIdQuery : IRequest<NotificacionesResponse>
{
    public NotificacionesGetByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}