using CleanArchitecture.Application.Models.APIComunes;
using MediatR;

namespace CleanArchitecture.Application.Features.AccesoOsprera.Commands.Update;

public class UpdateAccesoOspreraCommand : IRequest<int>
{
    public int Id { get; set; }
    public required DateTime Fecha { get; set; }
    public required string? UsuarioId { get; set; }
    public required int? SeccionalId { get; set; }
    public required long? CUITTitular { get; set; }
    public required long? DniPaciente { get; set; }
    public required int TipoDocumentoId { get; set; }
    public required string? NombreyApellido { get; set; }
    public required DateTime? FechaNacimiento { get; set; }
    public required int? SexoId { get; set; }
    public string? MedioGestion { get; set; }
    public string? Telefono { get; set; }
    public string? ResultadoLlamada { get; set; }
    public string? DireccionesEmailDestino { get; set; }
    public string? Texto { get; set; }
    public DateTime? FechaEnvioMail { get; set; }
    public string? RespuestaEnvioEmail { get; set; }
    public ICollection<DocumentacionEntidad>? Documentacion { get; set; }
}