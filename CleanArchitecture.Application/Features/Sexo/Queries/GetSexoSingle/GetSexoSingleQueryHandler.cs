using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.Sexo.Queries.GetSexoSingle
{
    public class GetSexoSingleQueryHandler : IRequestHandler<GetSexoSingleQuery, SexoVm>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSexoSingleQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<SexoVm> Handle(GetSexoSingleQuery request, CancellationToken cancellationToken)
        {
            var sexoList = await _unitOfWork.Repository<Domain.Sexo>().GetByIdAsync(request.Id);

            return _mapper.Map<SexoVm>(sexoList);
        }
    }
}
