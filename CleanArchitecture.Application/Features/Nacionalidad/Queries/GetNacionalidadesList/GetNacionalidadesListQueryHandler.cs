using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.Provincia.Queries.GetNacionalidadesList
{
    public class GetNacionalidadesListQueryHandler : IRequestHandler<GetNacionalidadesListQuery, List<NacionalidadVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetNacionalidadesListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<NacionalidadVm>> Handle(GetNacionalidadesListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork.Repository<Domain.Nacionalidad>().GetAllAsync();

            return _mapper.Map<List<NacionalidadVm>>(list);
        }
    }
}
