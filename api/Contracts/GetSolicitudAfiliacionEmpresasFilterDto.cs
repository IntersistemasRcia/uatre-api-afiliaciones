using System;

namespace CleanArchitecture.API.Contracts.Requests.SolicitudAfiliacionEmpresas
{
    public class GetSolicitudAfiliacionEmpresasFilterDto
    {
        public int? EstadoSolicitudId { get; set; }
        public int? SeccionalId { get; set; }
        public string? EmpresaCUIT { get; set; }
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }

        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 300;
        public string? Sort { get; set; } = "-Id";
    }
}
