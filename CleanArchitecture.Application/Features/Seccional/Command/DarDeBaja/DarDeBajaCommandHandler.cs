using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Common.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Seccional.Command.DarDeBaja;

public class DarDeBajaCommandHandler : IRequestHandler<DarDeBajaCommand, int>
{
    private readonly ILogger<DarDeBajaCommandHandler> logger;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public DarDeBajaCommandHandler(ILogger<DarDeBajaCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(DarDeBajaCommand request, CancellationToken cancellationToken)
    {
        var entidad = await unitOfWork.Repository<Domain.Seccional>().GetByIdAsync(request.Id);
        if (entidad == null || entidad.DeletedDate != null)
        {
            throw new NotFoundException(nameof(Seccional), request.Id);
        }

        var patchModel = new JsonPatchDocument();

        try
        {
            patchModel.Replace(nameof(Domain.Seccional.DeletedObs), request.DeletedObs);

            unitOfWork.Repository<Domain.Seccional>().DarDeBajaAsync(entidad, patchModel);
            return await unitOfWork.CommitAsync();
        }
        catch (Exception)
        {
            throw;
        }        
    }
}
