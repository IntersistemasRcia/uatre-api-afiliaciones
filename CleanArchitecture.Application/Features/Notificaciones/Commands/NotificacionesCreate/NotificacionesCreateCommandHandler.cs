using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Common.Exceptions;
using CleanArchitecture.Domain;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Notificaciones.Commands.NotificacionesCreate;

public class NotificacionesCreateCommandHandler : IRequestHandler<NotificacionesCreateCommand, int>
{
    private readonly ILogger<NotificacionesCreateCommandHandler> logger;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public NotificacionesCreateCommandHandler(ILogger<NotificacionesCreateCommandHandler> logger,
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }
    public async Task<int> Handle(NotificacionesCreateCommand request, CancellationToken cancellationToken)
    {               
        var entidad = mapper.Map<Notificacion>(request);

        try
        {
            await unitOfWork.Repository<Notificacion>().AddAsync(entidad);

            return await unitOfWork.CommitAsync();           
        }
        catch (Exception)
        {
            logger.LogError($"No se insertó el registro de {nameof(Notificacion)}");
            throw new Exception($"No se pudo insertar {nameof(Notificacion)}");
        }
    }
}
