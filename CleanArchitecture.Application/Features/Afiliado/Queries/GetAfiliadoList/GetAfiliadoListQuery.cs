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
        public string? Nombre { get; set; }
        //public double? CUITEmpresa { get; set; }
        public string? Seccional { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaEgreso { get; set; }
        public int? EstadoSolicitudId { get; set; }
        public int? EmpresaId { get; set; }

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
