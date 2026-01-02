using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.SeccionalEstado.Responses;
using MediatR;

namespace CleanArchitecture.Application.Features.SeccionalEstado.Queries.GetSeccionalEstadoAll;

public class GetSeccionalEstadoAllQueryHandler : IRequestHandler<GetSeccionalEstadoAllQuery, IReadOnlyList<SeccionalEstadoResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetSeccionalEstadoAllQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<SeccionalEstadoResponse>> Handle(GetSeccionalEstadoAllQuery request, CancellationToken cancellationToken)
    {
        var list = await _unitOfWork.Repository<Domain.SeccionalEstado>().GetAllAsync();

        return _mapper.Map<List<SeccionalEstadoResponse>>(list);
    }
}
