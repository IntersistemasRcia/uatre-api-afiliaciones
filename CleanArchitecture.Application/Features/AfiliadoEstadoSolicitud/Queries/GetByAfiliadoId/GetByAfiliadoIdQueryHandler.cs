using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Specification.Implements;
using MediatR;

namespace CleanArchitecture.Application.Features.AfiliadoEstadoSolicitud.Queries.GetByAfiliadoId
{
    public class GetAfiliadoIdQueryHandler : IRequestHandler<GetByAfiliadoIdQuery, List<AfiliadoEstadoSolicitudVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAfiliadoIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<AfiliadoEstadoSolicitudVm>> Handle(GetByAfiliadoIdQuery request, CancellationToken cancellationToken)
        {
            var spec = new AfiliadoEstadoSolicitudSpec(request);
            var list = await _unitOfWork.Repository<Domain.AfiliadoEstadoSolicitud>().GetAllWithSpecsAsync(spec);

            return _mapper.Map<List<AfiliadoEstadoSolicitudVm>>(list);
        }
    }
}
