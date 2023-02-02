using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Specification;
using MediatR;

namespace CleanArchitecture.Application.Features.Afiliado.Queries.GetAfiliadoList
{
    public class GetAfiliadoListQueryHandler : IRequestHandler<GetAfiliadoListQuery, Pagination<AfiliadoVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAfiliadoListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Pagination<AfiliadoVm>> Handle(GetAfiliadoListQuery request, CancellationToken cancellationToken)
        {
            var spec = new AfiliadoSpecification(request);
            var padronList = await _unitOfWork.AfiliadoRepository.GetAllWithSpecsAsync(spec);

            var totalRecords = await _unitOfWork.AfiliadoRepository.CountAsync(new BaseSpecification<Domain.Afiliado>());
            var totalPages = Convert.ToInt32(Math.Ceiling(totalRecords / Convert.ToDecimal(request.GetPageSize())));

            var data = _mapper.Map<List<AfiliadoVm>>(padronList);

            return new Pagination<AfiliadoVm>()
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
