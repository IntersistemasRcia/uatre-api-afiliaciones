using CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesListSpecs;
using CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresas.Queries;
using CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresasDetalle.Queries;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Domain;
using MediatR;

namespace CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresas.Queries.GetSolicitudAfiliacionEmpresasListSpecs;

public class GetSolicitudAfiliacionEmpresasListSpecsQuery : IRequest<Pagination<SolicitudAfiliacionEmpresasVm>>
{
    private int _pageIndex { get; set; } = 1;
    private const int maxPageSize = 50;
    private int _pageSize = 50;

    public DateTime? Fecha { get; set; }
    public string? Seccional { get; set; }
    public int? SeccionalId { get; set; }
    public string? SeccionalCodigo { get; set; }
    public string? SeccionalDescripcion { get; set; }
    public int? EmpresaId { get; set; }
    public string? Empresa { get; set; }
    public string? EmpresaCUIT { get; set; }
    public string? EmpresaRazonSocial { get; set; }
    public int? EstadoSolicitudId { get; set; }
    public DateTime? EstadoFecha { get; set; }
    public string? EstadoSolicitudObservaciones { get; set; }
    public string? EstadoSolicitudUsuario { get; set; }
    public int? Periodo { get; set; }
    public Int64? Total_Trabajadores { get; set; }
    public int? Total_Trab_Rurales { get; set; }
    public int? Total_Trab_NoRurales { get; set; }
    public int? Total_Trab_Rurales_Afiliados { get; set; }
    public int? Total_Trab_Rurales_NoAfiliados { get; set; }
    public int? Total_Trab_NoRurales_Afiliados { get; set; }
    public int? Total_Trab_NoRurales_NoAfiliados { get; set; }
    public string? Sort { get; set; }
    public Ambito? AmbitoTodos { get; set; }
    public Ambito? AmbitoSeccionales { get; set; }
    public Ambito? AmbitoDelegaciones { get; set; }
    public Ambito? AmbitoProvincias { get; set; }
    public bool? VerDetalles { get; set; } = true;

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
