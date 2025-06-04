using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Specification.Implements;
using CleanArchitecture.Common.Exceptions;
using MediatR;
namespace CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresas.Queries.GetSolicitudAfiliacionEmpresasById;

public class GetSolicitudAfiliacionEmpresasByIdQueryHandler : IRequestHandler<GetSolicitudAfiliacionEmpresasByIdQuery, SolicitudAfiliacionEmpresasVm>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetSolicitudAfiliacionEmpresasByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<SolicitudAfiliacionEmpresasVm> Handle(GetSolicitudAfiliacionEmpresasByIdQuery request, CancellationToken cancellationToken)
    {
        var spec = new SolicitudAfiliacionEmpresasSpecification(request.Id);
        var entidad = await _unitOfWork.Repository<Domain.SolicitudAfiliacionEmpresas>().GetOneWithSpecsAsync(spec);
        if (entidad == null)
        {
            throw new NotFoundException(nameof(Domain.SolicitudAfiliacionEmpresas), request.Id);
        }

        var data = _mapper.Map<SolicitudAfiliacionEmpresasVm>(entidad);

        var empresa = await _unitOfWork.RefRepository.GetEmpresaById(entidad.EmpresaId);

        data.EmpresaDescripcion = empresa?.RazonSocial ?? string.Empty;
        data.EmpresaCUIT = empresa?.CUIT ?? 0;

        return data;
    }
}



