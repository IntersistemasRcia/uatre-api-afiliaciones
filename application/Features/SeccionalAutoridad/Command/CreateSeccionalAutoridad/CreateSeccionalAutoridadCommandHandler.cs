using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.SeccionalAutoridad.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Data;

namespace CleanArchitecture.Application.Features.SeccionalAutoridad.Command.CreateSeccionalAutoridad;

public class CreateSeccionalAutoridadCommandHandler : IRequestHandler<CreateSeccionalAutoridadCommand, int>
{
    private readonly ILogger<CreateSeccionalAutoridadCommand> logger;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    private readonly ISeccionalAutoridadBusinessValidator validator;

    public CreateSeccionalAutoridadCommandHandler(ILogger<CreateSeccionalAutoridadCommand> logger, IMapper mapper, IUnitOfWork unitOfWork, ISeccionalAutoridadBusinessValidator validator)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
        this.validator = validator;
    }
    public async Task<int> Handle(CreateSeccionalAutoridadCommand request, CancellationToken cancellationToken)
    {
        var entidad = mapper.Map<Domain.SeccionalAutoridad>(request);

        // Transacción con aislamiento serializable para evitar dos altas concurrentes que validen ambas OK
        using (var tx = await unitOfWork.BeginTransactionAsync(IsolationLevel.Serializable))
        {
            // Validación de negocio (lanza ConflictException o BadRequestException según corresponda)
            await validator.ValidateAsync(entidad, excludeId: null, isReactivation: false);

            await unitOfWork.Repository<Domain.SeccionalAutoridad>().AddAsync(entidad);
            var result = await unitOfWork.CommitAsync();

            if (result <= 0)
            {
                logger.LogError("No se insertó el registro de SeccionalAutoridad");
                throw new Exception("No se pudo insertar SeccionalAutoridad");
            }

            await tx.CommitAsync();
        }

        return entidad.Id;
    }
}
