using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Common.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polly;

namespace CleanArchitecture.Application.Features.Afiliado.Commands.ResolverSolicitudAfiliado
{
    public class PatchAfiliadoCommandHandler : IRequestHandler<PatchAfiliadoCommand, int>
    {
        private readonly ILogger<PatchAfiliadoCommand> logger;
        //private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public PatchAfiliadoCommandHandler(ILogger<PatchAfiliadoCommand> logger, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            //this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(PatchAfiliadoCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Inicia PatchAfiliadoCommandHandler");
            var afiliado = await unitOfWork.Repository<Domain.Afiliado>().GetByIdAsync(request.Id);

            if (afiliado == null)
            {
                logger.LogInformation("No existe Afiliado");
                throw new NotFoundException(typeof(Domain.Afiliado).Name, request.Id);
            }

            int estadoSolicitudAnt = afiliado.EstadoSolicitudId; 

            var patchModel = new JsonPatchDocument();

            patchModel.Replace(nameof(Domain.Afiliado.EstadoSolicitudId), request.EstadoSolicitudId);
            patchModel.Replace(nameof(Domain.Afiliado.EstadoSolicitudObservaciones), request.EstadoSolicitudObservaciones);
            switch (request.EstadoSolicitudId)
            {
                case 2: //activo
                    if (afiliado.EstadoSolicitudId == 1)
                    {
                        var nroAfiliado = unitOfWork.AfiliadoRepository.GetNroAfiliado();
                        patchModel.Replace(nameof(Domain.Afiliado.NroAfiliado), nroAfiliado);
                    }
                    patchModel.Replace(nameof(Domain.Afiliado.FechaIngreso), request.FechaIngreso ?? DateTime.Now);
                    break;

                case 3: //no activo
                    patchModel.Replace(nameof(Domain.Afiliado.FechaEgreso), request.FechaEgreso ?? DateTime.Now);
                    break;

                default:
                    break;
            }                        

            try
            {
                unitOfWork.Repository<Domain.Afiliado>().PatchAsync(afiliado, patchModel);                

                if (estadoSolicitudAnt != request.EstadoSolicitudId)
                {
                    //Auditoria con estado Anterior
                    Domain.AfiliadoEstadoSolicitud afiliadoEstadoSolicitud = new (afiliado.Id, estadoSolicitudAnt);
                    await unitOfWork.Repository<Domain.AfiliadoEstadoSolicitud>().AddAsync(afiliadoEstadoSolicitud);
                }

                return await unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                logger.LogError("No se actualizó el registro de Afiliado");
                throw new Exception("No se pudo resolver solicitud Afiliado");
            }              
        }
    }
}
