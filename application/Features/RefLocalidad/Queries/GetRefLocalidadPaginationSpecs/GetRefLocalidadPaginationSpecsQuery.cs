using CleanArchitecture.Application.Models;
using MediatR;

namespace CleanArchitecture.Application.Features.RefLocalidad.Queries.GetRefLocalidadPaginationSpecs;

public class GetRefLocalidadPaginationSpecsQuery : IRequest<Pagination<RefLocalidadVm>>
{
    private int _pageIndex { get; set; } = 1;
    private const int maxPageSize = 50;
    private int _pageSize = 50;

    public int? ProvinciaId { get; set; }
    public bool? Bajas { get; set; }

    public string? FilterByCPNombre { get; set; }

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
