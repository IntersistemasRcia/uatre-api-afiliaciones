using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.SeccionalAutoridad.Command.CreateSeccionalAutoridad;

public class CreateSeccionalAutoridadCommandHandler : IRequestHandler<CreateSeccionalAutoridadCommand, int>
{
    private readonly ILogger<CreateSeccionalAutoridadCommand> logger;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public CreateSeccionalAutoridadCommandHandler(ILogger<CreateSeccionalAutoridadCommand> logger, IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }
    public async Task<int> Handle(CreateSeccionalAutoridadCommand request, CancellationToken cancellationToken)
    {
        var entidad = mapper.Map<Domain.SeccionalAutoridad>(request);

        await unitOfWork.Repository<Domain.SeccionalAutoridad>().AddAsync(entidad);
        var result = await unitOfWork.CommitAsync();

        if (result <= 0)
        {
            logger.LogError("No se insertó el registro de SeccionalAutoridad");
            throw new Exception("No se pudo insertar SeccionalAutoridad");
        }

        return entidad.Id;
    }
}
