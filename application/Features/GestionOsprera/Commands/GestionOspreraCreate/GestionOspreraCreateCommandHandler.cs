using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Application.Features.GestionOsprera.Commands;
using MediatR;
using Microsoft.Extensions.Logging;
using CleanArchitecture.Application.Features.GestionOsprera.Commands.GestionOsprera;

namespace CleanArchitecture.Application.Features.GestionOsprera.Commands.GestionOspreraCreate;

internal class GestionOspreraCreateCommandHandler : IRequestHandler<GestionOspreraCreateCommand, int>
{
    private readonly ILogger<GestionOspreraCreateCommandHandler> logger;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public GestionOspreraCreateCommandHandler(ILogger<GestionOspreraCreateCommandHandler> logger,
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }
    public async Task<int> Handle(GestionOspreraCreateCommand request, CancellationToken cancellationToken)
    {
        var entidad = mapper.Map<Domain.GestionOsprera>(request);
        using (var transaction = await unitOfWork.BeginTransactionAsync())
        try
        {
            await unitOfWork.Repository<Domain.GestionOsprera>().AddAsync(entidad);
            var result = await unitOfWork.CommitAsync();

            if (request.Documentacion?.Count > 0)
            {
                await unitOfWork.RefRepository.AgregarDocumentacionEntidad(request.Documentacion, "O", entidad.Id);
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
