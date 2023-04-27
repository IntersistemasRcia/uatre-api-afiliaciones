using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Afiliado.Commands.PatchAfiliado
{
    public class PatchAfiliadoCommandHandler : IRequestHandler<PatchAfiliadoCommand, int>
    {
        private readonly ILogger<PatchAfiliadoCommand> logger;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public PatchAfiliadoCommandHandler(ILogger<PatchAfiliadoCommand> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(PatchAfiliadoCommand request, CancellationToken cancellationToken)
        {
            await unitOfWork.AfiliadoRepository.ResolverSolicitudAsync(request.Id, request.model!);

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
