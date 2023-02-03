using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Afiliado.Commands.CreateAfiliado
{
    public class CreateAfiliadoCommandHandler : IRequestHandler<CreateAfiliadoCommand, int>
    {
        private readonly ILogger<CreateAfiliadoCommandHandler> logger;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public CreateAfiliadoCommandHandler(ILogger<CreateAfiliadoCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateAfiliadoCommand request, CancellationToken cancellationToken)
        {
            var entidad = mapper.Map<Domain.Afiliado>(request);

            unitOfWork.Repository<Domain.Afiliado>().AddEntity(entidad);
            var result = await unitOfWork.CommitAsync();

            if (result <= 0)
            {
                logger.LogError("No se insertó el registro de director");
                throw new Exception("No se pudo insertar Director");
            }

            return entidad.Id;
        }
    }
}
