using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.GestionOsprera.Queries.GetByPersona;
using CleanArchitecture.Application.Features.GestionOsprera.Queries.GetGestionOspreraList;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Models.APIComunes;
using CleanArchitecture.Application.Specification;
using CleanArchitecture.Application.Specification.Implements;
using CleanArchitecture.Common.Exceptions;
using MediatR;

namespace CleanArchitecture.Application.Features.GestionOsprera.Queries.GetByCUIT;

public class GestionOspreraGetByCUITHandler : IRequestHandler<GestionOspreraGetByCUITQuery, GestionOspreraVm>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GestionOspreraGetByCUITHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<GestionOspreraVm> Handle(GestionOspreraGetByCUITQuery request, CancellationToken cancellationToken)
    {       
        var spec = new GestionOspreraSpecification(request.CUIT);
        var ultimaGestion = (await _unitOfWork.Repository<Domain.GestionOsprera>().GetAllWithSpecsAsync(spec)).LastOrDefault();
        if (ultimaGestion == null)
        {
            throw new NotFoundException($"No se encontraron registros para el CUIT", request.CUIT);
        }

        return _mapper.Map<GestionOspreraVm>(ultimaGestion);
    }
}
