using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Common.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.SeccionalContacto.Command.DarDeBajaSeccionalContacto;

public class DarDeBajaSeccionalContactoCommandHandler : IRequestHandler<DarDeBajaSeccionalContactoCommand, int>
{
    private readonly ILogger<DarDeBajaSeccionalContactoCommandHandler> logger;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public DarDeBajaSeccionalContactoCommandHandler(ILogger<DarDeBajaSeccionalContactoCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(DarDeBajaSeccionalContactoCommand request, CancellationToken cancellationToken)
    {
        var entidad = await unitOfWork.Repository<Domain.SeccionalContacto>().GetByIdAsync(request.Id);
        if (entidad == null || entidad.DeletedDate != null)
        {
            throw new NotFoundException(nameof(Seccional), request.Id);
        }

        var patchModel = new JsonPatchDocument();

        try
        {
            patchModel.Replace(nameof(Domain.SeccionalContacto.DeletedObs), request.DeletedObs);

            unitOfWork.Repository<Domain.SeccionalContacto>().DarDeBajaAsync(entidad, patchModel);
            return await unitOfWork.CommitAsync();
        }
        catch (Exception)
        {
            throw;
        }        
    }
}
