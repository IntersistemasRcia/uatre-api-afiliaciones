using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.GestionesEstado.Queries.GestionesEstadoAll;
using CleanArchitecture.Application.Models;
using MediatR;

namespace CleanArchitecture.Application.Features.GestionesAreaOsprera.Queries.GestionesAreaOspreraAll;

public class GestionesAreaOspreraAllHandler : IRequestHandler<GestionesAreaOspreraAllQuery, List<IdDescripcionVm>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GestionesAreaOspreraAllHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<List<IdDescripcionVm>> Handle(GestionesAreaOspreraAllQuery request, CancellationToken cancellationToken)
    {
        var list = await _unitOfWork.Repository<Domain.GestionAreaOsprera>().GetAllAsync();
        return _mapper.Map<List<IdDescripcionVm>>(list);
    }
}
