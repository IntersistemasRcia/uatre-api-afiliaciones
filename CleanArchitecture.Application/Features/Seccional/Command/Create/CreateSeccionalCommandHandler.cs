using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Seccional.Command.Create
{
    public class CreateSeccionalCommandHandler : IRequestHandler<CreateSeccionalCommand, CreateSeccionalVm>
    {
        private readonly ILogger<CreateSeccionalCommand> logger;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public CreateSeccionalCommandHandler(ILogger<CreateSeccionalCommand> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<CreateSeccionalVm> Handle(CreateSeccionalCommand request, CancellationToken cancellationToken)
        {
            var entidad = mapper.Map<Domain.Seccional>(request);

            try
            {
                await unitOfWork.Repository<Domain.Seccional>().AddAsync(entidad);

                if (request.Documentacion?.Count > 0)
                {
                    unitOfWork.RefRepository.AgregarDocumentacionEntidad(request.Documentacion, "S", entidad.Id);
                }

                var result = await unitOfWork.CommitAsync();

                return mapper.Map<CreateSeccionalVm>(entidad);
            }
            catch (Exception)
            {
                logger.LogError("No se insertó el registro de SeccionalAutoridad");
                throw new Exception("No se pudo insertar SeccionalAutoridad");
            }  
        }
    }
}
