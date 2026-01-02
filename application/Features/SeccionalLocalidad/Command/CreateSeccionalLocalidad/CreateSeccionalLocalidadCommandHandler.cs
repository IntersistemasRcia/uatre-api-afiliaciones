using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.SeccionalLocalidad.Queries;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.SeccionalLocalidad.Command.CreateSeccionalLocalidad;

public class CreateSeccionalLocalidadCommandHandler : IRequestHandler<CreateSeccionalLocalidadCommand, SeccionalLocalidadVm>
{
    private readonly ILogger<CreateSeccionalLocalidadCommandHandler> logger;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public CreateSeccionalLocalidadCommandHandler(ILogger<CreateSeccionalLocalidadCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }
    public async Task<SeccionalLocalidadVm> Handle(CreateSeccionalLocalidadCommand request, CancellationToken cancellationToken)
    {
        var entidad = mapper.Map<Domain.SeccionalLocalidad>(request);

        try
        {
            await unitOfWork.Repository<Domain.SeccionalLocalidad>().AddAsync(entidad);
            var result = await unitOfWork.CommitAsync();

            return mapper.Map<SeccionalLocalidadVm>(entidad);
        }
        catch (Exception ex)
        {
            logger.LogError($"No se insertó el registro de {typeof(Domain.SeccionalLocalidad)}");
            throw new Exception(ex.Message);
        }
        
    }
}
