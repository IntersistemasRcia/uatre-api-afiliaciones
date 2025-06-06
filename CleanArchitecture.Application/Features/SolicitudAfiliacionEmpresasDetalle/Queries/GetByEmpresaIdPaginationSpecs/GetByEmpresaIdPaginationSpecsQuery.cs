using CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresasDetalle.Queries;
using CleanArchitecture.Application.Models;
using MediatR;

namespace CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresasDetalle.Queries.GetByEmpresaIdPaginationSpecs;

public class GetByEmpresaIdPaginationSpecsQuery : IRequest<Pagination<SolicitudAfiliacionEmpresasDetalleVm>>
{
    private int _pageIndex { get; set; } = 1;
    private const int maxPageSize = 50;
    private int _pageSize = 50;

    public int? SolicitudAfiliacionEmpresasId { get; set; }

    public string? SortBy { get; set; }

    public int PageIndex
    {
        get => _pageIndex;
        set => _pageIndex = value;
    }
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value >= maxPageSize ? maxPageSize : value;
    }
}
