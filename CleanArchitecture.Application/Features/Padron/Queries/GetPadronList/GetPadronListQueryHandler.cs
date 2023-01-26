using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Specification;
using MediatR;

namespace CleanArchitecture.Application.Features.Padron.Queries.GetPadronList
{
    public class GetPadronListQueryHandler : IRequestHandler<GetPadronListQuery, Pagination<PadronVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPadronListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Pagination<PadronVm>> Handle(GetPadronListQuery request, CancellationToken cancellationToken)
        {            
            var spec = new PadronSpecification(request);
            var padronList = await _unitOfWork.PadronRepository.GetAllWithSpecsAsync(spec);

            var totalRecords = await _unitOfWork.PadronRepository.CountAsync(new BaseSpecification<Domain.Padron>());
            var totalPages = Convert.ToInt32(Math.Ceiling(totalRecords / Convert.ToDecimal(request.GetPageSize())));

            var data = _mapper.Map<List<PadronVm>>(padronList);

            return new Pagination<PadronVm>()
            {
                Index = request.GetPageIndex(),
                Size = request.GetPageSize(),
                Pages = totalPages,
                Count = totalRecords,
                Data = data
            };
        }
    }
}
