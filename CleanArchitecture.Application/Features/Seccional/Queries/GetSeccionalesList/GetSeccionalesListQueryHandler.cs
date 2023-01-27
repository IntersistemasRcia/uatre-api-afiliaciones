using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesList
{
    public class GetSeccionalesListQueryHandler : IRequestHandler<GetSeccionalesListQuery, List<SeccionalVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSeccionalesListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<SeccionalVm>> Handle(GetSeccionalesListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork.SeccionalRepository.GetAllAsync();

            return _mapper.Map<List<SeccionalVm>>(list);
        }
    }
}
