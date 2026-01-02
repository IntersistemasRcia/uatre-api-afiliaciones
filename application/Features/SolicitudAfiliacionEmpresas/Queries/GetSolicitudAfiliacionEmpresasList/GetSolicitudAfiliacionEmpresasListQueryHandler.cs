using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Specification.Implements;
using MediatR;


namespace CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresas.Queries.GetSolicitudAfiliacionEmpresasList
{
    public class GetSolicitudAfiliacionEmpresasListQueryHandler : IRequestHandler<GetSolicitudAfiliacionEmpresasListQuery, List<SolicitudAfiliacionEmpresasVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSolicitudAfiliacionEmpresasListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<SolicitudAfiliacionEmpresasVm>> Handle(GetSolicitudAfiliacionEmpresasListQuery request, CancellationToken cancellationToken)
        {
            var spec = new SolicitudAfiliacionEmpresasSpecification(request);
            var list = await _unitOfWork.Repository<Domain.SolicitudAfiliacionEmpresas>().GetAllWithSpecsAsync(spec);

            var data = _mapper.Map<List<SolicitudAfiliacionEmpresasVm>>(list.OrderBy(x => x.Id));

            foreach (var item in data)
            {
                var empresa = await _unitOfWork.RefRepository.GetEmpresaById(item.EmpresaId);
                item.EmpresaDescripcion = empresa?.RazonSocial ?? string.Empty;
                item.EmpresaCUIT = empresa?.CUIT ?? 0;
            }

            return data;
        }
    }
}
