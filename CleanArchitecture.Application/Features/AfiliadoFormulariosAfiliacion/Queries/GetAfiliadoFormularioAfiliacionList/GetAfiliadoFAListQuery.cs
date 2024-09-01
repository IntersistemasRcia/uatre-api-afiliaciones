using CleanArchitecture.Application.Features.Afiliado.Queries;
using CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesListSpecs;
using CleanArchitecture.Application.Models;
using MediatR;

namespace CleanArchitecture.Application.Features.AfiliadoFormulariosAfiliacion.Queries.GetAfiliadoFormularioAfiliacionList
{
    public class GetAfiliadoFAListQuery : IRequest<Pagination<AfiliadoFormulariosAfiliacionVm>>
    {
        private int _pageIndex { get; set; } = 1;
        private const int maxPageSize = 50;
        private int _pageSize = 50;

        public DateTime? Fecha { get; set; }
        public long? CUIL { get; set; }
        public string? Apellido { get; set; }
        public string? Nombre { get; set; }
        public string? Domicilio { get; set; }
        public string? Telefono { get; set; }
        public string? Celular { get; set; }
        public string? Email { get; set; }
        public int? SexoId { get; set; }
        public int? TipoDocumentoId { get; set; }
        public Int64? Documento { get; set; }
        public int? EstadoCicilId { get; set; }
        public string? EstadoCivil { get; set; }
        public int? SeccionalId { get; set; }
        public string? Seccional { get; set; }
        public int? OficioId { get; set; }
        public string? Oficio { get; set; }
        public int? ActividadIdAfiliado { get; set; }
        public string? ActividadAfiliado { get; set; }
        public int? NacionalidadId { get; set; }
        public string? Nacionalidad { get; set; }
        public int? RefLocalidadIdAfiliado { get; set; }
        public string? NombreLocalidadAfiliado { get; set; }
        public int? ProvinciaId { get; set; }
        public double? CUITEmpresa { get; set; }
        public string? RazonSocial { get; set; }
        public string? DomicilioEmpresa { get; set; }
        public int? RefLocalidadIdEmpresa { get; set; }
        public string? NombreLocalidadEmpresa { get; set; }
        public int? ProvinciaidEmpresa { get; set; }
        public int? ActividadIdEmpresa { get; set; }
        public string? ActividadEmpresa { get; set; }
        public string? TelefonoEmpresa { get; set; }
        public string? CelularEmpresa { get; set; }
        public string? EmailEmpresa { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public DateTime? FechaIncorporacion { get; set; }
        public DateTime? FechaIncorporacionHasta { get; set; }
        public int? AfiliadoIdAsignado { get; set; }
        public string? Observaciones { get; set; }
        public Guid? Guid { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string? DeletedBy { get; set; }
        public string? DeletedObs { get; set; }
        public Ambito? AmbitoTodos { get; set; }
        public Ambito? AmbitoDelegaciones { get; set; }
        public Ambito? AmbitoSeccionales { get; set; }
        public Ambito? AmbitoProvincias { get; set; }
        public DateTime? CreatedDateDesde { get; set; }
        public DateTime? CreatedDateHasta { get; set; }

        public string? Sort { get; set; }
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

        public GetAfiliadoFAListQuery()
        {
            //Id = pId ?? throw new ArgumentNullException(nameof(pId));
        }

        public int GetPageIndex() { return _pageIndex; }

        public int GetPageSize() { return _pageSize; }
    }
}
