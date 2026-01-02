using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.GestionesObraSocial.Queries.GetAll;

public class GestionesObraSocialGetAllHandler : IRequestHandler<GestionesObraSocialGetAllQuery, List<GestionObraSocialVm>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GestionesObraSocialGetAllHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<List<GestionObraSocialVm>> Handle(GestionesObraSocialGetAllQuery request, CancellationToken cancellationToken)
    {
        var list = await _unitOfWork.Repository<Domain.GestionObraSocial>().GetAllAsync();

        return _mapper.Map<List<GestionObraSocialVm>>(list);
    }
}
