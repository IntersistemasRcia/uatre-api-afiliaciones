using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.EstadoSolicitud.Queries.GetEstadosSolicitudesList
{
    public class GetEstadosSolicitudesListQueryHandler : IRequestHandler<GetEstadosSolicitudesListQuery, List<EstadoSolicitudVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetEstadosSolicitudesListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<EstadoSolicitudVm>> Handle(GetEstadosSolicitudesListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork.Repository<Domain.EstadoSolicitud>().GetAllAsync();

            return _mapper.Map<List<EstadoSolicitudVm>>(list);
        }
    }
}
