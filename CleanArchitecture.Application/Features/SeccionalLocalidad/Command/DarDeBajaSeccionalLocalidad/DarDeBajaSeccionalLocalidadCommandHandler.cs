using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Common.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.SeccionalLocalidad.Command.DarDeBajaSeccionalLocalidad;

public class DarDeBajaSeccionalLocalidadCommandHandler : IRequestHandler<DarDeBajaSeccionalLocalidadCommand, int>
{
    private readonly ILogger<DarDeBajaSeccionalLocalidadCommandHandler> logger;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public DarDeBajaSeccionalLocalidadCommandHandler(ILogger<DarDeBajaSeccionalLocalidadCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(DarDeBajaSeccionalLocalidadCommand request, CancellationToken cancellationToken)
    {
        var entidad = await unitOfWork.Repository<Domain.SeccionalLocalidad>().GetByIdAsync(request.Id);
        if (entidad == null || entidad.DeletedDate != null)
        {
            throw new NotFoundException(nameof(Seccional), request.Id);
        }

        var patchModel = new JsonPatchDocument();

        try
        {
            patchModel.Replace(nameof(Domain.SeccionalLocalidad.DeletedObs), request.DeletedObs);

            unitOfWork.Repository<Domain.SeccionalLocalidad>().DarDeBajaAsync(entidad, patchModel);
            return await unitOfWork.CommitAsync();
        }
        catch (Exception)
        {
            throw;
        }        
    }
}
