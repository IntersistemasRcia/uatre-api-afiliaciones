using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models;
using MediatR;

namespace CleanArchitecture.Application.Features.GestionesEstado.Queries.GestionesEstadoAll;

public class GestionesEstadoAllHandler : IRequestHandler<GestionesEstadoAllQuery, List<IdDescripcionVm>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GestionesEstadoAllHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<List<IdDescripcionVm>> Handle(GestionesEstadoAllQuery request, CancellationToken cancellationToken)
    {
        var list = await _unitOfWork.Repository<Domain.GestionEstado>().GetAllAsync();
        return _mapper.Map<List<IdDescripcionVm>>(list);
    }
}
