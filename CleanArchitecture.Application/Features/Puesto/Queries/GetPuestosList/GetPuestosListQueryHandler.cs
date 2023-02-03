using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.Puesto.Queries.GetPuestosList
{
    public class GetPuestosListQueryHandler : IRequestHandler<GetPuestosListQuery, List<PuestoVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPuestosListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<PuestoVm>> Handle(GetPuestosListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork.Repository<Domain.Puesto>().GetAllAsync();

            return _mapper.Map<List<PuestoVm>>(list);
        }
    }
}
