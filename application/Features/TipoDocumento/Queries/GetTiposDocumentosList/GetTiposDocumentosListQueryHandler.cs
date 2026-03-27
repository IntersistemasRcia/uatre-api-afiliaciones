using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;


namespace CleanArchitecture.Application.Features.TipoDocumento.Queries.GetTiposDocumentosList
{
    public class GetTiposDocumentosListQueryHandler : IRequestHandler<GetTiposDocumentosListQuery, List<TipoDocumentoVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTiposDocumentosListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<TipoDocumentoVm>> Handle(GetTiposDocumentosListQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork.Repository<Domain.TipoDocumento>().GetAllAsync();

            return _mapper.Map<List<TipoDocumentoVm>>(list);
        }
    }
}
