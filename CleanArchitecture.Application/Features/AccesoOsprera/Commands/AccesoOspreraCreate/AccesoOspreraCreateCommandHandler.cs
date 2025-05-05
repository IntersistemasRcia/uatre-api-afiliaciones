using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Application.Features.AccesoOsprera.Commands;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.AccesoOsprera.Commands.AccesoOspreraCreate;

internal class AccesoOspreraCreateCommandHandler : IRequestHandler<AccesoOspreraCreateCommand, int>
{
    private readonly ILogger<AccesoOspreraCreateCommandHandler> logger;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public AccesoOspreraCreateCommandHandler(ILogger<AccesoOspreraCreateCommandHandler> logger,
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }
    public async Task<int> Handle(AccesoOspreraCreateCommand request, CancellationToken cancellationToken)
    {
        var entidad = mapper.Map<Domain.AccesoOsprera>(request);

        try
        {
            await unitOfWork.Repository<Domain.AccesoOsprera>().AddAsync(entidad);

            return await unitOfWork.CommitAsync();
        }
        catch (Exception)
        {
            logger.LogError($"No se insertó el registro de {nameof(AccesoOsprera)}");
            throw new Exception($"No se pudo insertar {nameof(AccesoOsprera)}");
        }
    }
}
