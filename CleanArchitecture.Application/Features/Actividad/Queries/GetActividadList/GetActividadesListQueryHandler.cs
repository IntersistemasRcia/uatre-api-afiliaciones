using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using MediatR;

namespace CleanArchitecture.Application.Features.Actividad.Queries.GetActividadList
{
    public class GetActividadesListQueryHandler : IRequestHandler<GetActividadesListQuery, List<ActividadVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetActividadesListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ActividadVm>> Handle(GetActividadesListQuery request, CancellationToken cancellationToken)
        {
            var actividadList = await _unitOfWork.Repository<Domain.Actividad>().GetAllAsync();

            return _mapper.Map<List<ActividadVm>>(actividadList);
        }
    }
}
