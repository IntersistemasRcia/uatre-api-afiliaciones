using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.RefLocalidad.Command.Create;
using CleanArchitecture.Application.Features.RefLocalidad.Queries;
using CleanArchitecture.Common.Exceptions;
using CleanArchitecture.Domain;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.RefLocalidad.Command.Update;

public class UpdateRefLocalidadCommandHandler : IRequestHandler<UpdateRefLocalidadCommand, RefLocalidadVm>
{
    private readonly ILogger<UpdateRefLocalidadCommandHandler> logger;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    private readonly IValidator<UpdateRefLocalidadCommand> validator;

    public UpdateRefLocalidadCommandHandler(ILogger<UpdateRefLocalidadCommandHandler> logger, 
        IMapper mapper, 
        IUnitOfWork unitOfWork, 
        IValidator<UpdateRefLocalidadCommand> validator)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
        this.validator = validator;
    }

    public async Task<RefLocalidadVm> Handle(UpdateRefLocalidadCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            throw new BadRequestException(string.Join(Environment.NewLine, validationResult.Errors));
        }

        var entidad = await unitOfWork.Repository<Domain.RefLocalidad>().GetByIdAsync(request.Id);
        if (entidad == null)
        {
            logger.LogError("No existe RefLocalidad");
            throw new Exception("No existe RefLocalidad");
        }        

        mapper.Map(request, entidad, typeof(UpdateRefLocalidadCommand), typeof(Domain.RefLocalidad));

        var provincia = await unitOfWork.Repository<Domain.Provincia>().GetByIdAsync(entidad.ProvinciaId);
        entidad.LitProvincia = provincia.Nombre ?? entidad.LitProvincia ?? string.Empty;
        entidad.NombreCompleto = $"{entidad.Nombre} - {provincia.Nombre}";
        entidad.Tipo = "L";

        try
        {
            await unitOfWork.Repository<Domain.RefLocalidad>().UpdateAsync(entidad);

            await unitOfWork.CommitAsync();

            var data = mapper.Map<RefLocalidadVm>(entidad);

            //Busco el primer dato de SeccionalLocalidad
            var seccional = await unitOfWork.SeccionalRepository.GetFirstSeccionalLocalidadByRefLocalidadId(data.Id);

            data.SeccionalId = seccional.Id;
            data.SeccionalDescripcion = seccional.Descripcion;
            data.SeccionalCodigo = seccional.Codigo;

            return data;
        }
        catch (Exception)
        {
            logger.LogError("No se insertó el registro de RefLocalidad");
            throw new Exception("No se pudo insertar RefLocalidad");
        }
    }
}
