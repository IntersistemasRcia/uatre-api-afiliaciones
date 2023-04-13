using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Specification.Implements;
using MediatR;

namespace CleanArchitecture.Application.Features.SeccionalAutoridad.Queries.GetBySpecs
{
    public class GetSeccionalAutoridadBySpecsQueryHandler : IRequestHandler<GetSeccionalAutoridadBySpecsQuery, List<SeccionalAutoridadResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSeccionalAutoridadBySpecsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<SeccionalAutoridadResponse>> Handle(GetSeccionalAutoridadBySpecsQuery request, CancellationToken cancellationToken)
        {
            var spec = new SeccionalAutoridadSpecification(request);
            var list = await _unitOfWork.Repository<Domain.SeccionalAutoridad>().GetAllWithSpecsAsync(spec);

            return _mapper.Map<List<SeccionalAutoridadResponse>>(list);
        }
    }
}
