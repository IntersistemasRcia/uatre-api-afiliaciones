using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.SeccionalAutoridad.Command.UpdateSeccionalAutoridad;
using CleanArchitecture.Application.Features.SeccionalContacto.Command.UpdateSeccionalContacto;
using CleanArchitecture.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.SeccionalContacto.Command.UpdateSeccionalContacto;

public class UpdateSeccionalContactoCommandHandler : IRequestHandler<UpdateSeccionalContactoCommand, int>
{
    private readonly ILogger<UpdateSeccionalContactoCommandHandler> logger;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public UpdateSeccionalContactoCommandHandler(ILogger<UpdateSeccionalContactoCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }
    public async Task<int> Handle(UpdateSeccionalContactoCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entidad = await unitOfWork.Repository<Domain.SeccionalContacto>().GetByIdAsync(request.Id);
            if (entidad.DeletedDate != null)
            {
                throw new NotFoundException(nameof(Domain.SeccionalContacto), request.Id);
            }

            mapper.Map(request, entidad, typeof(UpdateSeccionalContactoCommand), typeof(Domain.SeccionalContacto));

            await unitOfWork.Repository<Domain.SeccionalContacto>().UpdateAsync(entidad);
            var result = await unitOfWork.CommitAsync();

            return entidad.Id;
        }
        catch (Exception ex)
        {
            logger.LogError("No se actualizó el registro de SeccionalContacto");
            throw new Exception("No se pudo actualizar SeccionalContacto " + ex.Message);
        }
    }
}
