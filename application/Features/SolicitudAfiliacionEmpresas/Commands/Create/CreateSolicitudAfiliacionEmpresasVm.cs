namespace CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresas.Commands.Create
{
    public class CreateSolicitudAfiliacionEmpresasVm
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
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
    }
}


