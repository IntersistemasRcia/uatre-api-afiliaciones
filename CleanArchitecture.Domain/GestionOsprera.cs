using CleanArchitecture.Domain.Commom;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain;

public class GestionOsprera : EntidadAuditable
{
    public required DateTime? Fecha { get; set; }
    public required string? UsuarioId { get; set; }
    public required int SeccionalId { get; set; }
    public required long? CUITTitular { get; set; }
    public required string? NombreTitular { get; set; }
    public required string? ApellidoTitular { get; set; }
    public string? TelefonoContacto { get; set; }
    public string? TelefonoContacto2 { get; set; }
    public string? EmailContacto { get; set; }
    public string? EmailContacto2 { get; set; }
    public bool? ElPacienteEsTitular { get; set; }
    public required int TipoDocumentoId { get; set; }
    public required long? DniPaciente { get; set; }
    public required string? NombrePaciente { get; set; }
    public required string? ApellidoPaciente { get; set; }
    [StringLength(100)]
    public required DateTime? FechaNacimiento { get; set; }
    public required int? SexoId { get; set; }
    public required string? MedioGestion { get; set; }
    public string? Telefono { get; set; }
    public string? ResultadoLlamada { get; set; }
    public string? DireccionesEmailDestino { get; set; }
    [StringLength(1000)]
    public string? Texto { get; set; }
    public DateTime? FechaEnvioMail { get; set; }
    public string? RespuestaEnvioEmail { get; set; }
    public int GestionRubroId { get; set; }
    public GestionRubro? GestionRubro { get; set; }
    public int GestionSubRubroId { get; set; }
    public GestionSubRubro? GestionSubRubro { get; set; }
    public int GestionEstadoId { get; set; }
    public GestionEstado? GestionEstado { get; set; }
    public int GestionSituacionId { get; set; }
    public GestionSituacion? GestionSituacion { get; set; }
    public int GestionAreaOspreraId { get; set; }
    public GestionAreaOsprera? GestionAreaOsprera { get; set; }

    [StringLength(1)]
    public string? AtencionesPrevias { get; set; }

    [StringLength(1)]
    public string? ConCoberturaOsprera  { get; set; }

    [StringLength(10)]
    public string? TipoPrestador { get; set; }
}
