using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.AfiliadoFormulariosAfiliacion.Commands.AfiliadoFormulariosAfiliacionCreate;

internal class AfiliadoFormulariosAfiliacionCreateCommandHandler : IRequestHandler<AfiliadoFormulariosAfiliacionCreateCommand, int>
{
    private readonly ILogger<AfiliadoFormulariosAfiliacionCreateCommandHandler> logger;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public AfiliadoFormulariosAfiliacionCreateCommandHandler(ILogger<AfiliadoFormulariosAfiliacionCreateCommandHandler> logger,
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }
    public async Task<int> Handle(AfiliadoFormulariosAfiliacionCreateCommand request, CancellationToken cancellationToken)
    {
        var entidad = mapper.Map<AfiliadoFormularioAfiliacion>(request);

        try
        {
            await unitOfWork.Repository<AfiliadoFormularioAfiliacion>().AddAsync(entidad);

            return await unitOfWork.CommitAsync();
        }
        catch (Exception)
        {
            logger.LogError($"No se insertó el registro de {nameof(AfiliadoFormularioAfiliacion)}");
            throw new Exception($"No se pudo insertar {nameof(AfiliadoFormularioAfiliacion)}");
        }
    }
}
