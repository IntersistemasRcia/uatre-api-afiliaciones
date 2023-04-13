using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.SeccionalAutoridad.Queries.GetById
{
    public class GetSeccionalAutoridadByIdQueryHandler : IRequestHandler<GetSeccionalAutoridadByIdQuery, SeccionalAutoridadResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSeccionalAutoridadByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<SeccionalAutoridadResponse> Handle(GetSeccionalAutoridadByIdQuery request, CancellationToken cancellationToken)
        {
            //var result = await _unitOfWork.Repository<Domain.SeccionalAutoridad>().GetByIdAsync(request.Id);
            var result = await _unitOfWork.SeccionalAutoridadRepository.GetSeccionalAutoridadCompletoById(request.Id);

            return _mapper.Map<SeccionalAutoridadResponse>(result);
        }
    }
}
