using CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesListSpecs;
using CleanArchitecture.Application.Models;
using MediatR;

namespace CleanArchitecture.Application.Features.Afiliado.Queries.GetAfiliadoList
{
    public class GetAfiliadoListQuery : IRequest<Pagination<AfiliadoVm>>
    {
        private int _pageIndex { get; set; } = 1;
        private const int maxPageSize = 50;
        private int _pageSize = 50;


        public long? CUIL { get; set; }
        public Int64? Documento { get; set; }
        public int? NroAfiliado { get; set; }
        public int? NroAfiliadoHasta { get; set; }
        public string? Nombre { get; set; }
        //public double? CUITEmpresa { get; set; }
        public string? Seccional { get; set; }
        public int? SeccionalEstadoId { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaIngresoHasta { get; set; }
        public DateTime? FechaEgreso { get; set; }
        public int? EstadoSolicitudId { get; set; }
        public int? EmpresaId { get; set; }
        public int? RefMotivoBajaId { get; set; }
        public bool SoloActivos { get; set; } = true;
        public DateTime? CreatedDateDesde { get; set; }
        public DateTime? CreatedDateHasta { get; set; }
        public Ambito? AmbitoTodos { get; set; }
        public Ambito? AmbitoDelegaciones { get; set; }
        public Ambito? AmbitoSeccionales { get; set; }
        public Ambito? AmbitoProvincias { get; set; }
        public Ambito? AmbitoSeccionalesActivas { get; set; }
        public Ambito? AmbitoSeccionalesDelegacionActivas { get; set; }

        //public string? FilterBy { get; set; }
        //public string? FilterValue { get; set; }

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

        public GetAfiliadoListQuery()
        {
            //Id = pId ?? throw new ArgumentNullException(nameof(pId));
        }

        public int GetPageIndex() { return _pageIndex; }

        public int GetPageSize() { return _pageSize; }
    }
}
