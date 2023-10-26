using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.RefLocalidad.Command.Update;

public class UpdateRefLocalidadCommandHandler : IRequestHandler<UpdateRefLocalidadCommand, int>
{
    private readonly ILogger<UpdateRefLocalidadCommandHandler> logger;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public UpdateRefLocalidadCommandHandler(ILogger<UpdateRefLocalidadCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(UpdateRefLocalidadCommand request, CancellationToken cancellationToken)
    {
        var entidad = await unitOfWork.Repository<Domain.RefLocalidad>().GetByIdAsync(request.Id);
        if (entidad == null)
        {
            logger.LogError("No existe RefLocalidad");
            throw new Exception("No existe RefLocalidad");
        }

        mapper.Map(request, entidad, typeof(UpdateRefLocalidadCommand), typeof(Domain.RefLocalidad));

        try
        {
            await unitOfWork.Repository<Domain.RefLocalidad>().UpdateAsync(entidad);

            return await unitOfWork.CommitAsync();
        }
        catch (Exception)
        {
            logger.LogError("No se insertó el registro de RefLocalidad");
            throw new Exception("No se pudo insertar RefLocalidad");
        }
    }
}
