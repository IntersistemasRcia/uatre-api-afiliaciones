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
        using (var transaction = await unitOfWork.BeginTransactionAsync())
        try
        {
            await unitOfWork.Repository<Domain.AccesoOsprera>().AddAsync(entidad);
            var result = await unitOfWork.CommitAsync();

            if (request.Documentacion?.Count > 0)
            {
                await unitOfWork.RefRepository.AgregarDocumentacionEntidad(request.Documentacion, "A", entidad.Id);
            }

            await transaction.CommitAsync();

            return entidad.Id;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();

            logger.LogError("No se insertó la Gestión");
            throw new Exception("No se pudo insertar la Gestión. " + ex.InnerException);
        }
    }
}
