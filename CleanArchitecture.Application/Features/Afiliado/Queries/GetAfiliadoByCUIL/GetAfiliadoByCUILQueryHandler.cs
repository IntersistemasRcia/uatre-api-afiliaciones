using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models.APIComunes;
using CleanArchitecture.Application.Specification.Implements;
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

            var documentacion = await _unitOfWork.RefRepository.GetDocumentacionEntidadById("A", afiliado.Id);

            var afiliadoVm = _mapper.Map<Domain.Afiliado, AfiliadoVm>(afiliado);
            afiliadoVm.Documentacion = new List<DocumentacionEntidad>();

            foreach (var item in documentacion)
            {
                afiliadoVm.Documentacion.Add(item);
            }

            return afiliadoVm;
        }
    }
}
