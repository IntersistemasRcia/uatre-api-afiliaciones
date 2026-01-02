using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Specification.Implements;
using MediatR;

namespace CleanArchitecture.Application.Features.SeccionalContacto.Queries.GetBySpecs
{
    public class GetSeccionalContactoBySpecsQueryHandler : IRequestHandler<GetSeccionalContactoBySpecsQuery, List<SeccionalContactoResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSeccionalContactoBySpecsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<SeccionalContactoResponse>> Handle(GetSeccionalContactoBySpecsQuery request, CancellationToken cancellationToken)
        {
            var spec = new SeccionalContactoSpecification(request);
            var list = await _unitOfWork.Repository<Domain.SeccionalContacto>().GetAllWithSpecsAsync(spec);

            return _mapper.Map<List<SeccionalContactoResponse>>(list);
        }
    }
}
