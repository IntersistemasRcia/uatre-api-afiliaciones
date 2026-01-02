using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.SeccionalAutoridad.Command.UpdateSeccionalAutoridad;

public class UpdateAutoridadCommandHandler : IRequestHandler<UpdateSeccionalAutoridadCommand, int>
{
    private readonly ILogger<UpdateAutoridadCommandHandler> logger;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public UpdateAutoridadCommandHandler(ILogger<UpdateAutoridadCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }
    public async Task<int> Handle(UpdateSeccionalAutoridadCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entidad = await unitOfWork.Repository<Domain.SeccionalAutoridad>().GetByIdAsync(request.Id);
            if (entidad.DeletedDate != null)
            {
                throw new NotFoundException(nameof(Domain.SeccionalContacto), request.Id);
            }

            mapper.Map(request, entidad, typeof(UpdateSeccionalAutoridadCommand), typeof(Domain.SeccionalAutoridad));

            await unitOfWork.Repository<Domain.SeccionalAutoridad>().UpdateAsync(entidad);
            var result = await unitOfWork.CommitAsync();

            return entidad.Id;
        }
        catch (Exception ex)
        {
            logger.LogError("No se actualizó el registro de SeccionalAutoridad");
            throw new Exception("No se pudo actualizar SeccionalAutoridad " + ex.Message);
        }  
    }
}
