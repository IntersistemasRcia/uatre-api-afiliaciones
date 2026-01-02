using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.Notificaciones.Queries.NotificacionesSpecs;
using CleanArchitecture.Domain;
using MediatR;

namespace CleanArchitecture.Application.Features.Notificaciones.Queries.NotificacionesGet;

public class NotificacionesGetQueryHandler : IRequestHandler<NotificacionesGetQuery, IReadOnlyList<NotificacionesResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public NotificacionesGetQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<NotificacionesResponse>> Handle(NotificacionesGetQuery request, CancellationToken cancellationToken)
    {
        var spec = new NotificacionesGetSpecs(request);
        var entidad = await _unitOfWork.Repository<Notificacion>().GetAllWithSpecsAsync(spec);
        
        return _mapper.Map<IReadOnlyList<NotificacionesResponse>>(entidad);
    }
}

