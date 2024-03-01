using CleanArchitecture.Application.Models;
using MediatR;

namespace CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesListSpecs;

public class GetSeccionalesListSpecsQuery : IRequest<Pagination<SeccionalVm>>
{
    private int _pageIndex { get; set; } = 1;
    private const int maxPageSize = 50;
    private int _pageSize = 50;

    public string? Provincia { get; set; }
    public int? ProvinciaId { get; set; }
    public string? Localidad { get; set; }
    public int? LocalidadId { get; set; }
    public int? CodigoPostal { get; set; }
    public int? RefDelegacionId { get; set; }
    public bool SoloActivos { get; set; } = true;
    public string? Sort { get; set; }
    public Ambito? AmbitoTodos { get; set; }
    public Ambito? AmbitoSeccionales { get; set; }
    public Ambito? AmbitoDelegaciones { get; set; }
    public Ambito? AmbitoProvincias { get; set; }

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

    public int GetPageIndex() { return _pageIndex; }

    public int GetPageSize() { return _pageSize; }
}

public class Ambito
{
    public List<int> Ids { get; set; }
}
