using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.Actividad.Queries.GetActividadList
{
    public class GetActividadListQueryHandler : IRequestHandler<GetActividadListQuery, List<ActividadVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetActividadListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ActividadVm>> Handle(GetActividadListQuery request, CancellationToken cancellationToken)
        {
            var actividadList = await _unitOfWork.ActividadRepository.GetAllAsync();

            return _mapper.Map<List<ActividadVm>>(actividadList);
        }
    }
}
