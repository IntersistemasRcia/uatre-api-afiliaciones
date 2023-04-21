using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.SeccionalContacto.Command.Create
{
    public class CreateSeccionalContactoCommandHandler : IRequestHandler<CreateSeccionalContactoCommand, int>
    {
        private readonly ILogger<CreateSeccionalContactoCommand> logger;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public CreateSeccionalContactoCommandHandler(ILogger<CreateSeccionalContactoCommand> logger, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateSeccionalContactoCommand request, CancellationToken cancellationToken)
        {
            var entidad = mapper.Map<Domain.SeccionalContacto>(request);

            await unitOfWork.Repository<Domain.SeccionalContacto>().AddAsync(entidad);
            var result = await unitOfWork.CommitAsync();

            if (result <= 0)
            {
                logger.LogError("No se insertó el registro de SeccionalContacto");
                throw new Exception("No se pudo insertar SeccionalContacto");
            }

            return entidad.Id;
        }
    }
}
