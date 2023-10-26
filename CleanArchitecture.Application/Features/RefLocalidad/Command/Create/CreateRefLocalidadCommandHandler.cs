using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.RefLocalidad.Command.Create;

public class CreateRefLocalidadCommandHandler : IRequestHandler<CreateRefLocalidadCommand, int>
{
    private readonly ILogger<CreateRefLocalidadCommandHandler> logger;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public CreateRefLocalidadCommandHandler(ILogger<CreateRefLocalidadCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }
    public async Task<int> Handle(CreateRefLocalidadCommand request, CancellationToken cancellationToken)
    {
        var entidad = mapper.Map<Domain.RefLocalidad>(request);

        try
        {
            await unitOfWork.Repository<Domain.RefLocalidad>().AddAsync(entidad);

            return await unitOfWork.CommitAsync();
        }
        catch (Exception)
        {
            logger.LogError("No se insertó el registro de RefLocalidad");
            throw new Exception("No se pudo insertar RefLocalidad");
        }
    }
}
