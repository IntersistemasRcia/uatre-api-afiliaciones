using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;


namespace CleanArchitecture.Application.Features.SeccionalContacto.Queries.GetById
{
    public class GetSeccionalContactoByIdQueryHandler : IRequestHandler<GetSeccionalContactoByIdQuery, SeccionalContactoResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSeccionalContactoByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<SeccionalContactoResponse> Handle(GetSeccionalContactoByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Repository<Domain.SeccionalContacto>().GetByIdAsync(request.Id);

            return _mapper.Map<SeccionalContactoResponse>(result);
        }
    }
}
