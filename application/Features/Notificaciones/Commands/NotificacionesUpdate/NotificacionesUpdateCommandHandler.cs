using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.Notificaciones.Commands.NotificacionesCreate;
using CleanArchitecture.Common.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Notificaciones.Commands.NotificacionesUpdate;

public class NotificacionesUpdateCommandHandler : IRequestHandler<NotificacionesUpdateCommand, int>
{
    private readonly ILogger<NotificacionesUpdateCommandHandler> logger;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public NotificacionesUpdateCommandHandler(ILogger<NotificacionesUpdateCommandHandler> logger,
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }
    public async Task<int> Handle(NotificacionesUpdateCommand request, CancellationToken cancellationToken)
    {
        var entidad = mapper.Map<Notificacion>(request);
        var existeEntidad = await unitOfWork.Repository<Notificacion>().GetByIdAsync(entidad.Id);
        if (existeEntidad == null)
        {
            throw new BadRequestException($"No existe {nameof(Notificacion)} con valor {request.Id}");
        }

        try
        {
            await unitOfWork.Repository<Notificacion>().UpdateAsync(entidad);

            return await unitOfWork.CommitAsync();
        }
        catch (Exception)
        {
            logger.LogError($"No se actualizó el registro de {nameof(Notificacion)}");
            throw new Exception($"No se pudo actualizar {nameof(Notificacion)}");
        }
    }
}
