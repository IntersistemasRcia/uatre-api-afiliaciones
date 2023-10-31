using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.SeccionalAutoridad.Command.ReactivarSeccionalAutoridad;

public class ReactivarDarDeBajaSeccionalAutoridadCommandHandler : IRequestHandler<ReactivarDarDeBajaSeccionalAutoridadCommand, int>
{
    private readonly ILogger<ReactivarDarDeBajaSeccionalAutoridadCommandHandler> logger;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public ReactivarDarDeBajaSeccionalAutoridadCommandHandler(ILogger<ReactivarDarDeBajaSeccionalAutoridadCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(ReactivarDarDeBajaSeccionalAutoridadCommand request, CancellationToken cancellationToken)
    {
        var entidad = await unitOfWork.Repository<Domain.SeccionalAutoridad>().GetByIdAsync(request.Id);
        if (entidad == null || entidad.DeletedDate == null)
        {
            throw new NotFoundException(nameof(Seccional), request.Id);
        }

        var patchModel = new JsonPatchDocument();

        try
        {
            patchModel.Replace(nameof(Domain.SeccionalAutoridad.DeletedDate), null);
            patchModel.Replace(nameof(Domain.SeccionalAutoridad.DeletedBy), null);
            patchModel.Replace(nameof(Domain.SeccionalAutoridad.DeletedObs), null);

            unitOfWork.Repository<Domain.SeccionalAutoridad>().ReactivarAsync(entidad, patchModel);
            return await unitOfWork.CommitAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
