using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.SeccionalAutoridad.Queries.GetBySeccional
{
    public class GetSeccionalAutoridadesbySeccionalQueryHandler : IRequestHandler<GetSeccionalAutoridadesBySeccionalQuery, IReadOnlyCollection<SeccionalAutoridadResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSeccionalAutoridadesbySeccionalQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IReadOnlyCollection<SeccionalAutoridadResponse>> Handle(GetSeccionalAutoridadesBySeccionalQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork.SeccionalAutoridadRepository.GetSeccionalAutoridadesBySeccional(request.SeccionalId, request.SoloActivos);

            return _mapper.Map<IReadOnlyCollection<SeccionalAutoridadResponse>>(list);
        }
    }
}
