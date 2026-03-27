using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Common.Exceptions;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Features.Afiliado.Commands.UpdateDatosAfip
{
    public class PatchAfiliadoDatosAfipCommandHandler : IRequestHandler<PatchAfiliadoDatosAfipCommand, int>
    {
        private readonly ILogger<PatchAfiliadoDatosAfipCommand> logger;
        //private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public PatchAfiliadoDatosAfipCommandHandler(ILogger<PatchAfiliadoDatosAfipCommand> logger, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            //this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(PatchAfiliadoDatosAfipCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Inicia PatchAfiliadoCommandHandler");

            var afiliado = await unitOfWork.Repository<Domain.Afiliado>().GetByIdAsync(request.Id);

            if (afiliado == null)
            {
                logger.LogInformation("No existe Afiliado");
                throw new NotFoundException(typeof(Domain.Afiliado).Name, request.Id);
            }

            var patchModel = new JsonPatchDocument();

            patchModel.Replace(nameof(Domain.Afiliado.AFIPFechaNacimiento), request.AFIPFechaNacimiento);
            patchModel.Replace(nameof(Domain.Afiliado.AFIPNombre), request.AFIPNombre);
            patchModel.Replace(nameof(Domain.Afiliado.AFIPApellido), request.AFIPApellido);
            patchModel.Replace(nameof(Domain.Afiliado.AFIPRazonSocial), request.AFIPRazonSocial);
            patchModel.Replace(nameof(Domain.Afiliado.AFIPTipoDocumento), request.AFIPTipoDocumento);
            patchModel.Replace(nameof(Domain.Afiliado.AFIPNumeroDocumento), request.AFIPNumeroDocumento);
            patchModel.Replace(nameof(Domain.Afiliado.AFIPTipoPersona), request.AFIPTipoPersona);
            patchModel.Replace(nameof(Domain.Afiliado.AFIPTipoClave), request.AFIPTipoClave);
            patchModel.Replace(nameof(Domain.Afiliado.AFIPEstadoClave), request.AFIPEstadoClave);
            patchModel.Replace(nameof(Domain.Afiliado.AFIPClaveInactivaAsociada), request.AFIPClaveInactivaAsociada);
            patchModel.Replace(nameof(Domain.Afiliado.AFIPFechaFallecimiento), request.AFIPFechaFallecimiento);
            patchModel.Replace(nameof(Domain.Afiliado.AFIPFormaJuridica), request.AFIPFormaJuridica);
            patchModel.Replace(nameof(Domain.Afiliado.AFIPActividadPrincipal), request.AFIPActividadPrincipal);
            patchModel.Replace(nameof(Domain.Afiliado.AFIPIdActividadPrincipal), request.AFIPIdActividadPrincipal);
            patchModel.Replace(nameof(Domain.Afiliado.AFIPPeriodoActividadPrincipal), request.AFIPPeriodoActividadPrincipal);
            patchModel.Replace(nameof(Domain.Afiliado.AFIPFechaContratoSocial), request.AFIPFechaContratoSocial);
            patchModel.Replace(nameof(Domain.Afiliado.AFIPMesCierre), request.AFIPMesCierre);
            patchModel.Replace(nameof(Domain.Afiliado.AFIPDomicilioDireccion), request.AFIPDomicilioDireccion);
            patchModel.Replace(nameof(Domain.Afiliado.AFIPDomicilioCalle), request.AFIPDomicilioCalle);
            patchModel.Replace(nameof(Domain.Afiliado.AFIPDomicilioNumero), request.AFIPDomicilioNumero);
            patchModel.Replace(nameof(Domain.Afiliado.AFIPDomicilioPiso), request.AFIPDomicilioPiso);
            patchModel.Replace(nameof(Domain.Afiliado.AFIPDomicilioDepto), request.AFIPDomicilioDepto);
            patchModel.Replace(nameof(Domain.Afiliado.AFIPDomicilioSector), request.AFIPDomicilioSector);
            patchModel.Replace(nameof(Domain.Afiliado.AFIPDomicilioTorre), request.AFIPDomicilioTorre);
            patchModel.Replace(nameof(Domain.Afiliado.AFIPDomicilioManzana), request.AFIPDomicilioManzana);
            patchModel.Replace(nameof(Domain.Afiliado.AFIPDomicilioLocalidad), request.AFIPDomicilioLocalidad);
            patchModel.Replace(nameof(Domain.Afiliado.AFIPDomicilioProvincia), request.AFIPDomicilioProvincia);
            patchModel.Replace(nameof(Domain.Afiliado.AFIPDomicilioIdProvincia), request.AFIPDomicilioIdProvincia);
            patchModel.Replace(nameof(Domain.Afiliado.AFIPDomicilioCodigoPostal), request.AFIPDomicilioCodigoPostal);
            patchModel.Replace(nameof(Domain.Afiliado.AFIPDomicilioTipo), request.AFIPDomicilioTipo);
            patchModel.Replace(nameof(Domain.Afiliado.AFIPDomicilioEstado), request.AFIPDomicilioEstado);
            patchModel.Replace(nameof(Domain.Afiliado.AFIPDomicilioDatoAdicional), request.AFIPDomicilioDatoAdicional);
            patchModel.Replace(nameof(Domain.Afiliado. AFIPDomicilioTipoDatoAdicional), request.AFIPDomicilioTipoDatoAdicional);

            unitOfWork.Repository<Domain.Afiliado>().PatchAsync(afiliado, patchModel);

            try
            {
                return await unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                logger.LogError("No se actualizó el registro de Afiliado");
                throw new Exception("No se pudo resolver solicitud Afiliado");
            }
        }
    }
}
