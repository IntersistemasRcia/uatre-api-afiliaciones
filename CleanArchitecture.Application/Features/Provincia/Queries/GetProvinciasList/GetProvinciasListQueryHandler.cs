using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.Provincia.Queries.GetProvinciasList
{
    public class GetPuestosListQueryHandler : IRequestHandler<GetProvinciasListQuery, List<ProvinciaVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPuestosListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ProvinciaVm>> Handle(GetProvinciasListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork.Repository<Domain.Provincia>().GetAllAsync();

            return _mapper.Map<List<ProvinciaVm>>(list);
        }
    }
}
