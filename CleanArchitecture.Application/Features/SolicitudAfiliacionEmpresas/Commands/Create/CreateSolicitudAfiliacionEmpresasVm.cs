namespace CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresas.Commands.Create
{
    public class CreateSolicitudAfiliacionEmpresasVm
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public DateTime? EstadoFecha { get; set; }
        public string? EstadoSolicitudObservaciones { get; set; }
        public string? EstadoSolicitudUsuario { get; set; }
    }
}


