using CleanArchitecture.Domain.Commom;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain;

public class AccesoOsprera : EntidadAuditable
{
    public required DateTime? Fecha { get; set; }
    public required string? UsuarioId { get; set; }
    public required int SeccionalId { get; set; }
    public required long? CUITTitular { get; set; }
    public required long? DniPaciente { get; set; }
    [StringLength(100)]
    public required string? NombreyApellido { get; set; }
    public required DateTime? FechaNacimiento { get; set; }
    public required int? SexoId { get; set; }
    [StringLength(1000)]
    public string? Texto { get; set; }
    public required DateTime? FechaEnvioMail { get; set; }
    public required string? DireccionesEmailDestino { get; set; }
    public string? RespuestaEnvioEmail { get; set; }
}
