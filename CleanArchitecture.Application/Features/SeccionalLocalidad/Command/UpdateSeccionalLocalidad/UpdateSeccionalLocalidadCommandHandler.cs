using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models.APIComunes;
using CleanArchitecture.Application.Specification;
using CleanArchitecture.Common.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.SeccionalLocalidad.Command.UpdateSeccionalLocalidad;

public class UpdateSeccionalLocalidadCommandHandler : IRequestHandler<UpdateSeccionalLocalidadCommand, int>
{
    private readonly ILogger<UpdateSeccionalLocalidadCommandHandler> logger;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;

    public UpdateSeccionalLocalidadCommandHandler(ILogger<UpdateSeccionalLocalidadCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(UpdateSeccionalLocalidadCommand request, CancellationToken cancellationToken)
    {
        var entidad = await unitOfWork.Repository<Domain.Seccional>().GetByIdAsync(request.SeccionalId);
        if (entidad == null)
        {
            logger.LogError("No existe Seccional");
            throw new Exception("No existe Seccional");
        }

        try
        {
            string errorMessage = string.Empty;

            if (request.SeccionalLocalidad == null || request.SeccionalLocalidad.Count == 0)
            {
                logger.LogError("No existen RefLocalidades");
                throw new Exception("No existen RefLocalidades");
            }

            foreach (var seccionalLocalidad in request.SeccionalLocalidad)
            {
                var registro = await unitOfWork.Repository<Domain.SeccionalLocalidad>()
                    .GetOneWithSpecsAsync(new BaseSpecification<Domain.SeccionalLocalidad>(x => x.RefLocalidadId == seccionalLocalidad.RefLocalidadId && x.SeccionalId == entidad.Id));

                if (registro == null)
                {
                    registro = new Domain.SeccionalLocalidad();
                    registro.SeccionalId = entidad.Id;
                    registro.RefLocalidadId = seccionalLocalidad.RefLocalidadId;
                    await unitOfWork.Repository<Domain.SeccionalLocalidad>().AddAsync(registro);
                }
                else
                {
                    errorMessage = $"{nameof(RefLocalidad)} {seccionalLocalidad.RefLocalidadId} ya está asignada a la Seccional";
                    break;
                }
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                throw new BadRequestException(errorMessage);
            }

            return await unitOfWork.CommitAsync();
        }
        catch(BadRequestException ex)
        {
            throw new BadRequestException(ex.Message);
        }
        catch (Exception)
        {
            logger.LogError("No se actualizó el registro de Seccional");
            throw new Exception("No se pudo insertar Seccional");
        }
    }
}
