using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Specification;
using MediatR;

namespace CleanArchitecture.Application.Features.DDJJUatre.Queries.GetDDJJUatreByCUIL
{
    public class GetDDJJUatreByCUILListQueryHandler : IRequestHandler<GetDDJJUatreByCUILListQuery, List<DDJJUatreVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDDJJUatreByCUILListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<DDJJUatreVm>> Handle(GetDDJJUatreByCUILListQuery request, CancellationToken cancellationToken)
        {
            var spec = new DDJJUatreSpecification(request);
            var list = await _unitOfWork.Repository<Domain.DDJJUatre>().GetAllWithSpecsAsync(spec);
            var finalList = list.OrderByDescending(x => x.Periodo).Take(12);

            return _mapper.Map<List<DDJJUatreVm>>(finalList);
        }
    }
}
