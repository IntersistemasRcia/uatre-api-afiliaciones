using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.EstadoCivil.Queries.GetEstadoCivilList
{
    public class GetEstadoCivilListQueryHandler : IRequestHandler<GetEstadoCivilListQuery, List<EstadoCivilVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetEstadoCivilListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<EstadoCivilVm>> Handle(GetEstadoCivilListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork.Repository<Domain.EstadoCivil>().GetAllAsync();

            return _mapper.Map<List<EstadoCivilVm>>(list);
        }
    }
}
