using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.GestionesSubRubro.Queries.GetAll;

public class GestionesSubRubroGetAllHandler : IRequestHandler<GestionesSubRubroGetAllQuery, List<GestionSubRubroVm>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GestionesSubRubroGetAllHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<List<GestionSubRubroVm>> Handle(GestionesSubRubroGetAllQuery request, CancellationToken cancellationToken)
    {
        var list = await _unitOfWork.Repository<Domain.GestionSubRubro>().GetAllAsync();

        return _mapper.Map<List<GestionSubRubroVm>>(list);
    }
}
