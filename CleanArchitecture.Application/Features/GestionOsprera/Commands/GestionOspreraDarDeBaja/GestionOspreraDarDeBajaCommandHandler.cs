using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.GestionOsprera.Commands.GestionOsprera;
using CleanArchitecture.Application.Models.APIComunes;
using CleanArchitecture.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.GestionOsprera.Commands.GestionOspreraDarDeBaja;

public class GestionOspreraDarDeBajaCommandHandler : IRequestHandler<GestionOspreraDarDeBajaCommand, int>
{
    private readonly ILogger<GestionOspreraDarDeBajaCommandHandler> logger;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public GestionOspreraDarDeBajaCommandHandler(ILogger<GestionOspreraDarDeBajaCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(GestionOspreraDarDeBajaCommand request, CancellationToken cancellationToken)
    {
        var entidad = await unitOfWork.Repository<Domain.GestionOsprera>().GetByIdAsync(request.Id);
        if (entidad == null || entidad.DeletedDate != null)
        {
            throw new NotFoundException(nameof(GestionOsprera), request.Id);
        }

        var patchModel = new JsonPatchDocument();

        try
        {
            patchModel.Replace(nameof(Domain.GestionOsprera.DeletedObs), request.DeletedObs);
            unitOfWork.Repository<Domain.GestionOsprera>().DarDeBajaAsync(entidad, patchModel);
            return await unitOfWork.CommitAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
}

