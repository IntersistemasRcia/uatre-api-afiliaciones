using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Specification.Implements;
using MediatR;

namespace CleanArchitecture.Application.Features.GestionesSituacion.Queries.GestionesSituacionByEstado;

public class GestionesSituacionByEstadoHandler : IRequestHandler<GestionesSituacionByEstadoQuery, List<IdDescripcionVm>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GestionesSituacionByEstadoHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<List<IdDescripcionVm>> Handle(GestionesSituacionByEstadoQuery request, CancellationToken cancellationToken)
    {
        var list = await _unitOfWork.Repository<Domain.GestionSituacion>().GetAllWithSpecsAsync(new GestionSituacionSpec(request.GestionEstadoId));
        return _mapper.Map<List<IdDescripcionVm>>(list);
    }
}
