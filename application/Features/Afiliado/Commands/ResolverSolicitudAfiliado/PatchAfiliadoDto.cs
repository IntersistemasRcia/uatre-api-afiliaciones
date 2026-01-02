namespace CleanArchitecture.Application.Features.Afiliado.Commands.ResolverSolicitudAfiliado;

public class PatchAfiliadoDto
{
    public required int EstadoSolicitudId { get; set; }
    public DateTime? FechaIngreso { get; set; }
    public DateTime? FechaEgreso { get; set; }
    public string? EstadoSolicitudObservaciones { get; set; }
    public int? RefMotivoBajaId { get; set; }
}
