using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.SeccionalLocalidad.Command.ReactivarSeccionalLocalidad;

public class ReactivarSeccionalLocalidadCommandHandler : IRequestHandler<ReactivarSeccionalLocalidadCommand, int>
{
    private readonly ILogger<ReactivarSeccionalLocalidadCommandHandler> logger;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public ReactivarSeccionalLocalidadCommandHandler(ILogger<ReactivarSeccionalLocalidadCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(ReactivarSeccionalLocalidadCommand request, CancellationToken cancellationToken)
    {
        var entidad = await unitOfWork.Repository<Domain.SeccionalLocalidad>().GetByIdAsync(request.Id);
        if (entidad == null || entidad.DeletedDate == null)
        {
            throw new NotFoundException(nameof(Seccional), request.Id);
        }

        var patchModel = new JsonPatchDocument();

        try
        {
            patchModel.Replace(nameof(Domain.SeccionalLocalidad.DeletedDate), null);
            patchModel.Replace(nameof(Domain.SeccionalLocalidad.DeletedBy), null);
            patchModel.Replace(nameof(Domain.SeccionalLocalidad.DeletedObs), null);

            unitOfWork.Repository<Domain.SeccionalLocalidad>().ReactivarAsync(entidad, patchModel);
            return await unitOfWork.CommitAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
