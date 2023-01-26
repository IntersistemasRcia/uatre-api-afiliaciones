using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.Actividad.Queries;
using CleanArchitecture.Application.Features.Actividad.Queries.GetActividadList;
using MediatR;

namespace CleanArchitecture.Application.Features.Sexo.Queries.GetSexoList
{
    public class GetSexoListQueryHandler : IRequestHandler<GetSexoListQuery, List<SexoVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSexoListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<SexoVm>> Handle(GetSexoListQuery request, CancellationToken cancellationToken)
        {
            var sexoList = await _unitOfWork.SexoRepository.GetAllAsync();

            return _mapper.Map<List<SexoVm>>(sexoList);
        }
    }
}
