using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesByProvinciaList;
using CleanArchitecture.Application.Specification;
using MediatR;

namespace CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesByCPList
{
    public class GetSeccionalesByProvinciaListQueryHandler : IRequestHandler<GetSeccionalesByProvinciaListQuery, List<SeccionalVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSeccionalesByProvinciaListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<SeccionalVm>> Handle(GetSeccionalesByProvinciaListQuery request, CancellationToken cancellationToken)
        {
            var spec = new SeccionalSpecification(request);
            var list = await _unitOfWork.Repository<Domain.Seccional>().GetAllWithSpecsAsync(spec);

            return _mapper.Map<List<SeccionalVm>>(list);
        }
    }
}
