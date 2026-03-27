using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Common.Exceptions;
using CleanArchitecture.Domain;
using MediatR;

namespace CleanArchitecture.Application.Features.Notificaciones.Queries.NotificacionesGetById;

public class NotificacionesGetByIdQueryHandler : IRequestHandler<NotificacionesGetByIdQuery, NotificacionesResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public NotificacionesGetByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<NotificacionesResponse> Handle(NotificacionesGetByIdQuery request, CancellationToken cancellationToken)
    {
        var entidad = await _unitOfWork.Repository<Notificacion>().GetByIdAsync(request.Id);
        if (entidad is null)
        {
            throw new NotFoundException(nameof(Notificacion), request.Id);
        }

        return _mapper.Map<NotificacionesResponse>(entidad);
    }
}
