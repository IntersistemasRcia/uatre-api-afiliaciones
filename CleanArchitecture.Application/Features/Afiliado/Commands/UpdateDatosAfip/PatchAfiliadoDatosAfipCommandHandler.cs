using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Common.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Afiliado.Commands.UpdateDatosAfip
{
    public class PatchAfiliadoDatosAfipCommandHandler : IRequestHandler<PatchAfiliadoDatosAfipCommand, int>
    {
        private readonly ILogger<PatchAfiliadoDatosAfipCommand> logger;
        //private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public PatchAfiliadoDatosAfipCommandHandler(ILogger<PatchAfiliadoDatosAfipCommand> logger, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            //this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(PatchAfiliadoDatosAfipCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Inicia PatchAfiliadoCommandHandler");
            var afiliado = await unitOfWork.Repository<Domain.Afiliado>().GetByIdAsync(request.Id);

            if (afiliado == null)
            {
                logger.LogInformation("No existe Afiliado");
                throw new NotFoundException(typeof(Domain.Afiliado).Name, request.Id);
            }

            unitOfWork.AfiliadoRepository.UpdateDatosAfip(afiliado, request.DatosAfipModel!);

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
