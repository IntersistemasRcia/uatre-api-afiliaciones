using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Specification;
using CleanArchitecture.Application.Specification.Implements;
using MediatR;


namespace CleanArchitecture.Application.Features.RefLocalidad.Queries.GetRefLocalidadByProvincia
{
    public class GetRefLocalidadByProvinciaQueryHandler : IRequestHandler<GetRefLocalidadByProvinciaQuery, List<RefLocalidadVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetRefLocalidadByProvinciaQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<RefLocalidadVm>> Handle(GetRefLocalidadByProvinciaQuery request, CancellationToken cancellationToken)
        {
            var spec = new RefLocalidadSpecification(request);
            var list = await _unitOfWork.Repository<Domain.RefLocalidad>().GetAllWithSpecsAsync(spec);

            return _mapper.Map<List<RefLocalidadVm>>(list);
        }
    }
}
