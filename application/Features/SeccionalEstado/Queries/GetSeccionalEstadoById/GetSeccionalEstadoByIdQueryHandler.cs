using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.SeccionalEstado.Responses;
using MediatR;


namespace CleanArchitecture.Application.Features.SeccionalEstado.Queries.GetSeccionalEstadoById;

public class GetSeccionalEstadoByIdQueryHandler : IRequestHandler<GetSeccionalEstadoByIdQuery, SeccionalEstadoResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetSeccionalEstadoByIdQueryHandler(IUnitOfWork unitOfWork, 
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<SeccionalEstadoResponse> Handle(GetSeccionalEstadoByIdQuery request, CancellationToken cancellationToken)
    {
        var record = await _unitOfWork.Repository<Domain.SeccionalEstado>().GetByIdAsync(request.Id);

        return _mapper.Map<SeccionalEstadoResponse>(record);
    }
}
