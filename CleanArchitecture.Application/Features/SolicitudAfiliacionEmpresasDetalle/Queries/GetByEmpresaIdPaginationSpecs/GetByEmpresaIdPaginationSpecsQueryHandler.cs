using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Specification;
using CleanArchitecture.Application.Specification.Implements;
using MediatR;

namespace CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresasDetalle.Queries.GetByEmpresaIdPaginationSpecs;

public class GetByEmpresaIdPaginationSpecsQueryHandler : IRequestHandler<GetByEmpresaIdPaginationSpecsQuery, Pagination<SolicitudAfiliacionEmpresasDetalleVm>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetByEmpresaIdPaginationSpecsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Pagination<SolicitudAfiliacionEmpresasDetalleVm>> Handle(GetByEmpresaIdPaginationSpecsQuery request, CancellationToken cancellationToken)
    {
        var spec = new GetByEmpresaIdPaginationSpecs(request);
        var list = await _unitOfWork.Repository<Domain.SolicitudAfiliacionEmpresasDetalle>().GetAllWithSpecsAsync(spec);

        var totalRecords = await _unitOfWork.Repository<Domain.SolicitudAfiliacionEmpresasDetalle>().CountAsync(new BaseSpecification<Domain.SolicitudAfiliacionEmpresasDetalle>(spec.Criteria));
        var totalPages = Convert.ToInt32(Math.Ceiling(totalRecords / Convert.ToDecimal(request.PageSize)));

        var data = _mapper.Map<List<SolicitudAfiliacionEmpresasDetalleVm>>(list);


        return new Pagination<SolicitudAfiliacionEmpresasDetalleVm>()
        {
            Index = request.PageIndex,
            Size = request.PageSize,
            Pages = totalPages,
            Count = totalRecords,
            Data = data
        };
    }
}
