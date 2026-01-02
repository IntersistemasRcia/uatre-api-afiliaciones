using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models.APIComunes;
using CleanArchitecture.Application.Specification.Implements;
using CleanArchitecture.Common.Exceptions;
using MediatR;

namespace CleanArchitecture.Application.Features.Afiliado.Queries.GetAfiliadoByCUILValidado
{
    public class GetAfiliadoByCUILValidadoQueryHandler : IRequestHandler<GetAfiliadoByCUILValidadoQuery, AfiliadoVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAfiliadoByCUILValidadoQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AfiliadoVm> Handle(GetAfiliadoByCUILValidadoQuery request, CancellationToken cancellationToken)
        {
            var spec = new AfiliadoByCUILValidadoSpec(request, true);
            var afiliado = await _unitOfWork.Repository<Domain.Afiliado>().GetOneWithSpecsAsync(spec);
            if (afiliado == null)
            {
                spec = new AfiliadoByCUILValidadoSpec(request, false);
                afiliado = await _unitOfWork.Repository<Domain.Afiliado>().GetOneWithSpecsAsync(spec);
                if (afiliado == null)
                {
                    throw new NotFoundException(nameof(Domain.Afiliado), request.CUIL);
                }
            }

            var afiliadoVm = _mapper.Map<AfiliadoVm>(afiliado);

            var empresa = await _unitOfWork.RefRepository.GetEmpresaById(afiliadoVm.EmpresaId);
            afiliadoVm.EmpresaDescripcion = empresa?.RazonSocial ?? "";
            afiliadoVm.EmpresaCUIT = empresa?.CUIT ?? 0;

            var refDelegacion = await _unitOfWork.RefRepository.GetDelegacionById(afiliadoVm.RefDelegacionId);
            afiliadoVm.RefDelegacionDescripcion = refDelegacion?.Nombre ?? "";

            var refMotivoBaja = await _unitOfWork.RefRepository.GetRefMotivoBajaById(afiliadoVm.RefMotivoBajaId);
            afiliadoVm.RefMotivoBajaDescripcion = refMotivoBaja?.Descripcion ?? string.Empty;
            afiliadoVm.RefMotivoBajaNoPermitirReactivarAfiliado = refMotivoBaja?.NoPermitirReactivarAfiliado ?? false;

            var seccionalAfiliacion = await _unitOfWork.Repository<Domain.Seccional>().GetByIdAsync(afiliadoVm.SeccionalIdSolicitudAfiliacion);
            afiliadoVm.SeccionalDescripcionSolicitudAfiliacion = seccionalAfiliacion?.Descripcion ?? string.Empty;
            afiliadoVm.SeccionalCodigoSolicitudAfiliacion = seccionalAfiliacion?.Codigo ?? string.Empty;

            // Documentacion
            afiliadoVm.Documentacion = new List<DocumentacionEntidad>();
            var documentacion = await _unitOfWork.RefRepository.GetDocumentacionEntidadById("A", afiliadoVm.Id);
            foreach (var item in documentacion)
            {
                afiliadoVm.Documentacion.Add(item);
            }

            return afiliadoVm;
        }
    }
}
