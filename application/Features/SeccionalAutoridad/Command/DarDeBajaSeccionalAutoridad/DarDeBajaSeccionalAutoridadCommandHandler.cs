using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Common.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.SeccionalAutoridad.Command.DarDeBajaSeccionalAutoridad;

public class DarDeBajaSeccionalAutoridadCommandHandler : IRequestHandler<DarDeBajaSeccionalAutoridadCommand, int>
{
    private readonly ILogger<DarDeBajaSeccionalAutoridadCommandHandler> logger;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public DarDeBajaSeccionalAutoridadCommandHandler(ILogger<DarDeBajaSeccionalAutoridadCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(DarDeBajaSeccionalAutoridadCommand request, CancellationToken cancellationToken)
    {
        var entidad = await unitOfWork.Repository<Domain.SeccionalAutoridad>().GetByIdAsync(request.Id);
        if (entidad == null || entidad.DeletedDate != null)
        {
            throw new NotFoundException(nameof(Seccional), request.Id);
        }

        var patchModel = new JsonPatchDocument();

        try
        {
            patchModel.Replace(nameof(Domain.SeccionalAutoridad.DeletedObs), request.DeletedObs);

            unitOfWork.Repository<Domain.SeccionalAutoridad>().DarDeBajaAsync(entidad, patchModel);
            return await unitOfWork.CommitAsync();
        }
        catch (Exception)
        {
            throw;
        }        
    }
}
