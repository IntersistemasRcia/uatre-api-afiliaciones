using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Specification;
using MediatR;

namespace CleanArchitecture.Application.Features.Afiliado.Queries.GetAfiliadoByCUIL
{
    public class GetAfiliadoByCUILQueryHandler : IRequestHandler<GetAfiliadoByCUILQuery, AfiliadoVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAfiliadoByCUILQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AfiliadoVm> Handle(GetAfiliadoByCUILQuery request, CancellationToken cancellationToken)
        {
            var spec = new AfiliadoByCUILSpecification(request);
            var afiliado = await _unitOfWork.Repository<Domain.Afiliado>().GetOneWithSpecsAsync(spec);

            return _mapper.Map<AfiliadoVm>(afiliado);
        }
    }
}
