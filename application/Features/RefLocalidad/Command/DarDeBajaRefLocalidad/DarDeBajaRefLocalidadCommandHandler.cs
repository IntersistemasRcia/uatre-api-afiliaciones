using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.RefLocalidad.Command.DarDeBajaRefLocalidad;

public class DarDeBajaRefLocalidadCommandHandler : IRequestHandler<DarDeBajaRefLocalidadCommand, int>
{
    private readonly ILogger<DarDeBajaRefLocalidadCommandHandler> logger;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public DarDeBajaRefLocalidadCommandHandler(ILogger<DarDeBajaRefLocalidadCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(DarDeBajaRefLocalidadCommand request, CancellationToken cancellationToken)
    {
        var entidad = await unitOfWork.Repository<Domain.RefLocalidad>().GetByIdAsync(request.Id);
        if (entidad == null || entidad.DeletedDate != null)
        {
            throw new NotFoundException(nameof(Domain.RefLocalidad), request.Id);
        }

        var patchModel = new JsonPatchDocument();

        try
        {
            patchModel.Replace(nameof(Domain.RefLocalidad.DeletedObs), request.DeletedObs);

            unitOfWork.Repository<Domain.RefLocalidad>().DarDeBajaAsync(entidad, patchModel);
            return await unitOfWork.CommitAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
