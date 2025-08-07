using CleanArchitecture.Application.Models.APIComunes;
using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Commom;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CleanArchitecture.Application.Features.GestionOsprera.Queries
{
    public class GestionOspreraVm : EntidadAuditable
    {

        public DateTime Fecha { get; set; }
        public string? UsuarioId { get; set; }
        public int? SeccionalId { get; set; }
        public long? CUITTitular { get; set; }
        public  string? NombreTitular { get; set; }
        public  string? ApellidoTitular { get; set; }
        public string? TelefonoContacto { get; set; }
        public string? TelefonoContacto2 { get; set; }
        public string? EmailContacto { get; set; }
        public string? EmailContacto2 { get; set; }
        public bool? ElPacienteEsTitular { get; set; }
        public  int TipoDocumentoId { get; set; }
        public  long? DniPaciente { get; set; }
        public  string? NombrePaciente { get; set; }
        public  string? ApellidoPaciente { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? SexoId { get; set; }
        public string? MedioGestion { get; set; }
        public string? Telefono { get; set; }
        public string? ResultadoLlamada { get; set; }
        public string? DireccionesEmailDestino { get; set; }
        public string? Texto { get; set; }
        public DateTime? FechaEnvioMail { get; set; }
        public string? RespuestaEnvioEmail { get; set; }

        public int GestionRubroId { get; set; }
        public string? GestionRubroDescripcion { get; set; }
        public int GestionSubRubroId { get; set; }
        public string? GestionSubRubroDescripcion { get; set; }
        public int GestionEstadoId { get; set; }
        public string? GestionEstadoDescripcion { get; set; }
        public int GestionSituacionId { get; set; }
        public string? GestionSituacionDescripcion { get; set; }
        public int GestionAreaOspreraId { get; set; }
        public string? GestionAreaOspreraDescripcion { get; set; }
        public string? AtencionesPrevias { get; set; }
        public string? ConCoberturaOsprera { get; set; }
        public string? TipoPrestador { get; set; }
        public string? ObservacionesEstado { get; set; }
        public ICollection<DocumentacionEntidad>? Documentacion { get; set; }
    }
}
