using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.GestionOsprera.Commands.GestionOspreraReactivar;
using CleanArchitecture.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.GestionOsprera.Commands.GestionOspreraReactivar;


public class GestionOspreraReactivarCommandHandler : IRequestHandler<GestionOspreraReactivarCommand, int>
{
    private readonly ILogger<GestionOspreraReactivarCommandHandler> logger;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public GestionOspreraReactivarCommandHandler(ILogger<GestionOspreraReactivarCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(GestionOspreraReactivarCommand request, CancellationToken cancellationToken)
    {
        var entidad = await unitOfWork.Repository<Domain.GestionOsprera>().GetByIdAsync(request.Id);
        if (entidad == null || entidad.DeletedDate == null)
        {
            throw new NotFoundException(nameof(GestionOsprera), request.Id);
        }

        var patchModel = new JsonPatchDocument();

        try
        {
            patchModel.Replace(nameof(Domain.GestionOsprera.DeletedDate), null);
            patchModel.Replace(nameof(Domain.GestionOsprera.DeletedBy), null);
            patchModel.Replace(nameof(Domain.GestionOsprera.DeletedObs), null);

            unitOfWork.Repository<Domain.GestionOsprera>().ReactivarAsync(entidad, patchModel);
            return await unitOfWork.CommitAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
}


