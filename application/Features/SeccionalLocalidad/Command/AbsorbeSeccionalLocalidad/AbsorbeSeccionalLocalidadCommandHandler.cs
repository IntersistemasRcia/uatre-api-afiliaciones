using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.SeccionalAutoridad.Command.UpdateSeccionalAutoridad;
using CleanArchitecture.Application.Features.SeccionalEstado.Queries.GetSeccionalEstadoAll;
using CleanArchitecture.Application.Features.SeccionalEstado.Responses;
using CleanArchitecture.Application.Features.SeccionalLocalidad.Queries;
using CleanArchitecture.Application.Specification;
using CleanArchitecture.Application.Specification.Implements;
using CleanArchitecture.Common.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CleanArchitecture.Application.Features.SeccionalLocalidad.Command.AbsorbeSeccionalLocalidad;

public class AbsorbeSeccionalLocalidadCommandHandler(ILogger<AbsorbeSeccionalLocalidadCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork) : IRequestHandler<AbsorbeSeccionalLocalidadCommand, int>
{
    private readonly ILogger<AbsorbeSeccionalLocalidadCommandHandler> logger = logger;
    private readonly IMapper mapper = mapper;
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public async Task<int> Handle(AbsorbeSeccionalLocalidadCommand request, CancellationToken cancellationToken)
    {
        var absobente = await unitOfWork.Repository<Domain.Seccional>().GetByIdAsync(request.SeccionalIdAbsorbente);
        var absobida = await unitOfWork.Repository<Domain.Seccional>().GetByIdAsync(request.SeccionalIdAbsorbida);
        var localidadesAbsorbidas = new List<Domain.SeccionalLocalidad>(
                await unitOfWork.Repository<Domain.SeccionalLocalidad>()
                    .GetAllWithSpecsAsync(new SeccionalLocalidadPorSeccionalSpecification(request.SeccionalIdAbsorbida))
            );
        if (localidadesAbsorbidas == null)
        {
            logger.LogError("No existen Localidades para esa Seccional Absorbida");
            throw new NotFoundException(nameof(Domain.SeccionalLocalidad), request.SeccionalIdAbsorbida);
        }
   

        try
        {            
            var localidadesAbsorbentes = await unitOfWork.Repository<Domain.SeccionalLocalidad>().GetAllWithSpecsAsync(new SeccionalLocalidadPorSeccionalSpecification(request.SeccionalIdAbsorbente));
            if (localidadesAbsorbentes != null)
            {
                localidadesAbsorbidas = new List<Domain.SeccionalLocalidad>(
                        localidadesAbsorbidas.Where((localidadABsorbida) => !localidadesAbsorbentes.Any(r => r.RefLocalidadId == localidadABsorbida.RefLocalidadId))
                    );

               /* if (!localidadesAbsorbidas.Any())
                {
                    logger.LogError("La seccional Absorvente ya tiene esas localidades");
                    throw new NotFoundException(nameof(Domain.SeccionalLocalidad), request.SeccionalIdAbsorbida);
                }*/
            }


            localidadesAbsorbidas?.ForEach(async (localidad) =>
            {
                var nueva = new Domain.SeccionalLocalidad()
                {
                    RefLocalidad = localidad.RefLocalidad,
                    RefLocalidadId = localidad.RefLocalidadId,
                    Seccional = absobente,
                    SeccionalId = absobente.Id
                };
                await unitOfWork.Repository<Domain.SeccionalLocalidad>().AddAsync(nueva);
            });

            

                var seccionalEstados = await unitOfWork.Repository<Domain.SeccionalEstado>().GetAllAsync();

            var estado = seccionalEstados.Where(x => x.Descripcion == "ABSORBIDA").ToList();

            if (estado.Count > 0) {
                absobida.SeccionalEstadoId = estado[0].Id;
                absobida.SeccionalAbsorbenteId = absobente.Id;
            }
            
            await unitOfWork.Repository<Domain.Seccional>().UpdateAsync(absobida);

            var result = await unitOfWork.CommitAsync();

            return result;
//            return mapper.Map<SeccionalLocalidadVm>(entidad);
        }
        catch (Exception ex)
        {
            logger.LogError($"No se actualizó el registro de {typeof(Domain.SeccionalLocalidad)}");
            throw new Exception($"No se pudo actualizar {typeof(Domain.SeccionalLocalidad)} {ex.Message}");
        }
    }
}
