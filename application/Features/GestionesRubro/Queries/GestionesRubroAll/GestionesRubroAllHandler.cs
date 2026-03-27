using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.GestionesRubro.Queries.GestionesRubroAll;

public class GestionesRubroAllHandler : IRequestHandler<GestionesRubroAllQuery, List<GestionRubroVm>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GestionesRubroAllHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<List<GestionRubroVm>> Handle(GestionesRubroAllQuery request, CancellationToken cancellationToken)
    {
        var list = await _unitOfWork.Repository<Domain.GestionRubro>().GetAllAsync();

        return _mapper.Map<List<GestionRubroVm>>(list);
    }
}
