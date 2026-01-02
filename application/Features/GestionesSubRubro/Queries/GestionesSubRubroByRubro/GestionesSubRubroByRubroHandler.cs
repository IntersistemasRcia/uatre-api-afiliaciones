using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Specification.Implements;
using MediatR;

namespace CleanArchitecture.Application.Features.GestionesSubRubro.Queries.GestionesSubRubroByRubro;

public class GestionesSubRubroByRubroHandler : IRequestHandler<GestionesSubRubroByRubroQuery, List<GestionSubRubroVm>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GestionesSubRubroByRubroHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<List<GestionSubRubroVm>> Handle(GestionesSubRubroByRubroQuery request, CancellationToken cancellationToken)
    {
        var list = await _unitOfWork.Repository<Domain.GestionSubRubro>().GetAllWithSpecsAsync(new GestionSubRubroSpec(request.GestionRubroId));

        return _mapper.Map<List<GestionSubRubroVm>>(list);
    }
}
