using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Specification;
using CleanArchitecture.Application.Specification.Implements;
using CleanArchitecture.Common.Exceptions;
using CleanArchitecture.Common.Helpers;
using MediatR;

namespace CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresas.Queries.GetSolicitudAfiliacionEmpresasListSpecs;

public class GetSolicitudAfiliacionEmpresasListSpecsQueryHandler : IRequestHandler<GetSolicitudAfiliacionEmpresasListSpecsQuery, Pagination<SolicitudAfiliacionEmpresasVm>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetSolicitudAfiliacionEmpresasListSpecsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<Pagination<SolicitudAfiliacionEmpresasVm>> Handle(GetSolicitudAfiliacionEmpresasListSpecsQuery request, CancellationToken cancellationToken)
    {
        var todos = request.AmbitoTodos != null ? true : false;
        if (!todos)
        {
            var validator = new GetSolicitudAfiliacionEmpresasListSpecsQueryValidator();
            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                throw new BadRequestException(result.Errors.Select(x => x.ErrorMessage).ToList().ToJsonString());
            }
        }

        var spec = new SolicitudAfiliacionEmpresasSpecification(request);
        var list = await _unitOfWork.Repository<Domain.SolicitudAfiliacionEmpresas>().GetAllWithSpecsAsync(spec);

        var totalRecords = await _unitOfWork.Repository<Domain.SolicitudAfiliacionEmpresas>().CountAsync(new BaseSpecification<Domain.SolicitudAfiliacionEmpresas>(spec.Criteria));
        var totalPages = Convert.ToInt32(Math.Ceiling(totalRecords / Convert.ToDecimal(request.GetPageSize())));
        var data = _mapper.Map<List<SolicitudAfiliacionEmpresasVm>>(list);

        foreach (var item in data)
        {
            var empresa = await _unitOfWork.RefRepository.GetEmpresaById(item.EmpresaId);

            item.EmpresaDescripcion = empresa?.RazonSocial ?? string.Empty;
            item.EmpresaCUIT = empresa?.CUIT ?? 0;
        }

        return new Pagination<SolicitudAfiliacionEmpresasVm>()
        {
            Index = request.GetPageIndex(),
            Size = request.GetPageSize(),
            Pages = totalPages,
            Count = totalRecords,
            Data = data
        };
    }
}
