using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.RefLocalidad.Command.ReactivarRefLocalidad;

public class ReactivarRefLocalidadCommandHandler : IRequestHandler<ReactivarRefLocalidadCommand, int>
{
    private readonly ILogger<ReactivarRefLocalidadCommandHandler> logger;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public ReactivarRefLocalidadCommandHandler(ILogger<ReactivarRefLocalidadCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(ReactivarRefLocalidadCommand request, CancellationToken cancellationToken)
    {
        var entidad = await unitOfWork.Repository<Domain.RefLocalidad>().GetByIdAsync(request.Id);
        if (entidad == null || entidad.DeletedDate == null)
        {
            throw new NotFoundException(nameof(Domain.RefLocalidad), request.Id);
        }

        var patchModel = new JsonPatchDocument();

        try
        {
            patchModel.Replace(nameof(Domain.RefLocalidad.DeletedDate), null);
            patchModel.Replace(nameof(Domain.RefLocalidad.DeletedBy), null);
            patchModel.Replace(nameof(Domain.RefLocalidad.DeletedObs), null);

            unitOfWork.Repository<Domain.RefLocalidad>().ReactivarAsync(entidad, patchModel);
            return await unitOfWork.CommitAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
