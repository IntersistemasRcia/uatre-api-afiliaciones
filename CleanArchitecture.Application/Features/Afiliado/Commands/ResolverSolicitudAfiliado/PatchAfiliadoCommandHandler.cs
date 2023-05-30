using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Common.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
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
            
            await unitOfWork.AfiliadoRepository.ResolverSolicitudAsync(afiliado, request.model!);

            try
            {
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
