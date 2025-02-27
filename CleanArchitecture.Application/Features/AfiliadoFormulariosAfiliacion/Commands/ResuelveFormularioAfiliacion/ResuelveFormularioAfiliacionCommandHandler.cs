using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Common.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.AfiliadoFormulariosAfiliacion.Command.ResuelveFormularioAfiliacion;

public class ResuelveFormularioAfiliacionCommandHandler : IRequestHandler<ResuelveFormularioAfiliacionCommand, int>
{
    private readonly ILogger<ResuelveFormularioAfiliacionCommandHandler> logger;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public ResuelveFormularioAfiliacionCommandHandler(ILogger<ResuelveFormularioAfiliacionCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(ResuelveFormularioAfiliacionCommand request, CancellationToken cancellationToken)
    {
        var entidad = await unitOfWork.Repository<Domain.AfiliadoFormularioAfiliacion>().GetByIdAsync(request.Id);
        if (entidad == null || entidad.DeletedDate != null)
        {
            throw new NotFoundException(nameof(AfiliadoFormularioAfiliacion), request.Id);
        }

        var patchModel = new JsonPatchDocument();

        try
        {
            if (request.DeletedObs == "" || request.DeletedObs == null)
            {
                patchModel.Replace(nameof(Domain.AfiliadoFormularioAfiliacion.AfiliadoIdAsignado), request.AfiliadoIdAsignado);
                unitOfWork.Repository<Domain.AfiliadoFormularioAfiliacion>().PatchAsync(entidad, patchModel);
            }
            else
            {
                patchModel.Replace(nameof(Domain.AfiliadoFormularioAfiliacion.DeletedObs), request.DeletedObs);
                unitOfWork.Repository<Domain.AfiliadoFormularioAfiliacion>().DarDeBajaAsync(entidad, patchModel);
            }
          
            
            return await unitOfWork.CommitAsync();
        }
        catch (Exception)
        {
            throw;
        }        
    }
}
