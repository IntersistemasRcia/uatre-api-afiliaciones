using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Seccional.Command.Reactivar;

public class ReactivarCommandHandler : IRequestHandler<ReactivarCommand, int>
{
    private readonly ILogger<ReactivarCommandHandler> logger;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public ReactivarCommandHandler(ILogger<ReactivarCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(ReactivarCommand request, CancellationToken cancellationToken)
    {
        var entidad = await unitOfWork.Repository<Domain.Seccional>().GetByIdAsync(request.Id);
        if (entidad == null || entidad.DeletedDate == null)
        {
            throw new NotFoundException(nameof(Seccional), request.Id);
        }

        var patchModel = new JsonPatchDocument();

        try
        {
            patchModel.Replace(nameof(Domain.Seccional.DeletedDate), null);
            patchModel.Replace(nameof(Domain.Seccional.DeletedBy), null);
            patchModel.Replace(nameof(Domain.Seccional.DeletedObs), null);
            patchModel.Replace(nameof(Domain.Seccional.Estado), request.Estado);

            unitOfWork.Repository<Domain.Seccional>().ReactivarAsync(entidad, patchModel);
            return await unitOfWork.CommitAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
