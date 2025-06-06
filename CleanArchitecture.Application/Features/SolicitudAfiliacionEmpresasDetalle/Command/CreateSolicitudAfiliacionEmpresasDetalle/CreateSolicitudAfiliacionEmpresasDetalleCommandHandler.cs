using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.SeccionalLocalidad.Command.CreateSeccionalLocalidad;
using CleanArchitecture.Application.Features.SeccionalLocalidad.Queries;
using CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresasDetalle.Command.CreateSolicitudAfiliacionEmpresasDetalle;
using CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresasDetalle.Queries;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresasDetalle.Command.CreateSolicitudAfiliacionEmpresasDetalle;

public class CreateSolicitudAfiliacionEmpresasDetalleCommandHandler : IRequestHandler<CreateSolicitudAfiliacionEmpresasDetalleCommand, SolicitudAfiliacionEmpresasDetalleVm>
{
    private readonly ILogger<CreateSolicitudAfiliacionEmpresasDetalleCommandHandler> logger;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public CreateSolicitudAfiliacionEmpresasDetalleCommandHandler(ILogger<CreateSolicitudAfiliacionEmpresasDetalleCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }
    public async Task<SolicitudAfiliacionEmpresasDetalleVm> Handle(CreateSolicitudAfiliacionEmpresasDetalleCommand request, CancellationToken cancellationToken)
    {
        var entidad = mapper.Map<Domain.SolicitudAfiliacionEmpresasDetalle>(request);
        try
        {
            await unitOfWork.Repository<Domain.SolicitudAfiliacionEmpresasDetalle>().AddAsync(entidad);
            var result = await unitOfWork.CommitAsync();

            return mapper.Map<SolicitudAfiliacionEmpresasDetalleVm>(entidad);
        }
        catch (Exception ex)
        {
            logger.LogError($"No se insertó el registro de {typeof(Domain.SolicitudAfiliacionEmpresasDetalle)}");
            throw new Exception(ex.Message);
        }
    }
}
