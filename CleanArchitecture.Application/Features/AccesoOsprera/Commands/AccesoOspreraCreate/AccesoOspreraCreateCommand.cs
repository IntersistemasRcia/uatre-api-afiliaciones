using MediatR;

namespace CleanArchitecture.Application.Features.AccesoOsprera.Commands.AccesoOspreraCreate;

public class AccesoOspreraCreateCommand : IRequest<int>
{
    public required DateTime Fecha { get; set; }
    public required string? UsuarioId { get; set; }
    public required int? SeccionalId { get; set; }
    public required long? CUITTitular { get; set; }
    public required long? DniPaciente { get; set; }
    public required string? NombreyApellido { get; set; }
    public required DateTime? FechaNacimiento { get; set; }
    public required int? SexoId { get; set; }
    public string? Texto { get; set; }
    public required DateTime? FechaEnvioMail { get; set; }
    public required string? DireccionesEmailDestino { get; set; }
    public string? RespuestaEnvioEmail { get; set; }
}
