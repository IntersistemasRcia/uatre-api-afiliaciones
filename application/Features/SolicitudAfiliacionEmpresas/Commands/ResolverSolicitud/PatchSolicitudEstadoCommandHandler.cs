using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Common.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polly;

namespace CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresas.Commands.ResolverSolicitud
{
    public class PatchSolicitudEstadoCommandHandler : IRequestHandler<PatchSolicitudEstadoCommand, int>
    {
        private readonly ILogger<PatchSolicitudEstadoCommand> logger;
        //private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public PatchSolicitudEstadoCommandHandler(ILogger<PatchSolicitudEstadoCommand> logger, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            //this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(PatchSolicitudEstadoCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Inicia PatchSolicitudEstadoCommandHandler");
            var solicitud = await unitOfWork.Repository<Domain.SolicitudAfiliacionEmpresas>().GetByIdAsync(request.Id);

            if (solicitud == null)
            {
                logger.LogInformation("No existe Solicitud");
                throw new NotFoundException(typeof(Domain.SolicitudAfiliacionEmpresas).Name, request.Id);
            }

            int estadoSolicitudAnt = solicitud.EstadoSolicitudId;

            var patchModel = new JsonPatchDocument();

            patchModel.Replace(nameof(Domain.SolicitudAfiliacionEmpresas.EstadoSolicitudId), request.EstadoSolicitudId);
            patchModel.Replace(nameof(Domain.SolicitudAfiliacionEmpresas.EstadoSolicitudObservaciones), request.EstadoSolicitudObservaciones ?? string.Empty);
            patchModel.Replace(nameof(Domain.SolicitudAfiliacionEmpresas.EstadoSolicitudUsuario), request.EstadoSolicitudUsuario ?? string.Empty);
            patchModel.Replace(nameof(Domain.SolicitudAfiliacionEmpresas.EstadoFecha), request.EstadoFecha ?? null);

            using (var transaction = await unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    unitOfWork.Repository<Domain.SolicitudAfiliacionEmpresas>().PatchAsync(solicitud, patchModel);

                    await transaction.CommitAsync();

                    return await unitOfWork.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();

                    logger.LogError("No se actualizó el registro de SolicitudAfiliacionEmpresas");
                    throw new Exception("No se pudo resolver solicitud SolicitudAfiliacionEmpresas");
                }
            }
        }
    }
}
