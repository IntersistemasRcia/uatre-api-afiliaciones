using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.SeccionalAutoridad.Command.UpdateSeccionalAutoridad;
using CleanArchitecture.Application.Features.SeccionalLocalidad.Queries;
using CleanArchitecture.Application.Specification;
using CleanArchitecture.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.SeccionalLocalidad.Command.UpdateRecordSeccionalLocalidad;

public class UpdateRecordSeccionalLocalidadCommandHandler : IRequestHandler<UpdateRecordSeccionalLocalidadCommand, SeccionalLocalidadVm>
{
    private readonly ILogger<UpdateRecordSeccionalLocalidadCommandHandler> logger;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public UpdateRecordSeccionalLocalidadCommandHandler(ILogger<UpdateRecordSeccionalLocalidadCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public async Task<SeccionalLocalidadVm> Handle(UpdateRecordSeccionalLocalidadCommand request, CancellationToken cancellationToken)
    {
        var entidad = await unitOfWork.Repository<Domain.SeccionalLocalidad>().GetByIdAsync(request.SeccionalId);
        if (entidad == null || entidad.DeletedDate != null)
        {
            logger.LogError("No existe SeccionalLocalidad");
            throw new NotFoundException(nameof(Domain.SeccionalLocalidad), request.Id);
        }

        try
        {            
            mapper.Map(request, entidad, typeof(UpdateRecordSeccionalLocalidadCommand), typeof(Domain.SeccionalLocalidad));

            await unitOfWork.Repository<Domain.SeccionalLocalidad>().UpdateAsync(entidad);
            var result = await unitOfWork.CommitAsync();

            return mapper.Map<SeccionalLocalidadVm>(entidad);
        }
        catch (Exception ex)
        {
            logger.LogError($"No se actualizó el registro de {typeof(Domain.SeccionalLocalidad)}");
            throw new Exception($"No se pudo actualizar {typeof(Domain.SeccionalLocalidad)} {ex.Message}");
        }
    }
}
