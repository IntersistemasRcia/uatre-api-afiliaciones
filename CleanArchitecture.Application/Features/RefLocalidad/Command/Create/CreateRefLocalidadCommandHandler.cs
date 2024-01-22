using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.Afiliado.Commands.CreateAfiliado;
using CleanArchitecture.Application.Features.RefLocalidad.Queries;
using CleanArchitecture.Common.Exceptions;
using CleanArchitecture.Domain;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.RefLocalidad.Command.Create;

public class CreateRefLocalidadCommandHandler : IRequestHandler<CreateRefLocalidadCommand, RefLocalidadVm>
{
    private readonly ILogger<CreateRefLocalidadCommandHandler> logger;
    private readonly IMapper mapper;
    private readonly IUnitOfWork unitOfWork;
    private readonly IValidator<CreateRefLocalidadCommand> validator;

    public CreateRefLocalidadCommandHandler(ILogger<CreateRefLocalidadCommandHandler> logger,
        IMapper mapper, 
        IUnitOfWork unitOfWork, 
        IValidator<CreateRefLocalidadCommand> validator)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.unitOfWork = unitOfWork;
        this.validator = validator;
    }
    public async Task<RefLocalidadVm> Handle(CreateRefLocalidadCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid) 
        {
            throw new BadRequestException(string.Join(Environment.NewLine, validationResult.Errors));
        }

        if (await unitOfWork.RefLocalidadRepository.ExisteRefLocalidadCodPostal(request.CodPostal) == true)
        {
            throw new BadRequestException($"Ya existe una Localidad con el Codigo Postal {request.CodPostal}");
        }

        var entidad = mapper.Map<Domain.RefLocalidad>(request);

        var provincia = await unitOfWork.Repository<Domain.Provincia>().GetByIdAsync(entidad.ProvinciaId);
        entidad.LitProvincia = provincia.Nombre ?? entidad.LitProvincia;
        entidad.NombreCompleto = $"{entidad.Nombre} - {provincia.Nombre}";
        entidad.Tipo = "L";

        try
        {            
            await unitOfWork.Repository<Domain.RefLocalidad>().AddAsync(entidad);            

            await unitOfWork.CommitAsync();
            
            await unitOfWork.Repository<Domain.SeccionalLocalidad>().AddAsync(new Domain.SeccionalLocalidad()
            {
                RefLocalidadId = entidad.Id,
                SeccionalId = provincia.SeccionalIdPorDefecto,
            });

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
