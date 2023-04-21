using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.Afiliado.Commands.CreateAfiliado;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

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
            var result = await unitOfWork.AfiliadoRepository.ResolverSolicitudAsync(request.Id, request.model!);

            await unitOfWork.CommitAsync();

            if (result <= 0)
            {
                logger.LogError("No se actualizó el registro de Afiliado");
                throw new Exception("No se pudo actualizar Afiliado");
            }

            return result;
        }
    }
}
