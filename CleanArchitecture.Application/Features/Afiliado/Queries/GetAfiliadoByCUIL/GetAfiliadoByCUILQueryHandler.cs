using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models.APIComunes;
using CleanArchitecture.Application.Specification.Implements;
using CleanArchitecture.Domain;
using MediatR;

namespace CleanArchitecture.Application.Features.Afiliado.Queries.GetAfiliadoByCUIL
{
    public class GetAfiliadoByCUILQueryHandler : IRequestHandler<GetAfiliadoByCUILQuery, AfiliadoVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAfiliadoByCUILQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AfiliadoVm> Handle(GetAfiliadoByCUILQuery request, CancellationToken cancellationToken)
        {
            var spec = new AfiliadoByCUILSpecification(request);
            var afiliado = await _unitOfWork.AfiliadoRepository.BuscarAfiliadoPorSpecs(spec);

            var refMotivoBaja = await _unitOfWork.RefRepository.GetById<RefMotivosBaja>(afiliado.RefMotivoBajaId);
            afiliado.RefMotivoBajaDescripcion = refMotivoBaja?.Descripcion ?? string.Empty;

            var documentacion = await _unitOfWork.RefRepository.GetDocumentacionEntidadById("A", afiliado.Id);

            var afiliadoVm = _mapper.Map<Domain.Afiliado, AfiliadoVm>(afiliado);
            afiliadoVm.Documentacion = new List<DocumentacionEntidad>();

            var seccionalAfiliacion = await _unitOfWork.Repository<Domain.Seccional>().GetByIdAsync(afiliado.SeccionalIdSolicitudAfiliacion);
            afiliadoVm.SeccionalDescripcionSolicitudAfiliacion = seccionalAfiliacion?.Descripcion ?? string.Empty;
            afiliadoVm.SeccionalCodigoSolicitudAfiliacion = seccionalAfiliacion?.Codigo ?? string.Empty;          

            foreach (var item in documentacion)
            {
                afiliadoVm.Documentacion.Add(item);
            }

            return afiliadoVm;
        }
    }
}
