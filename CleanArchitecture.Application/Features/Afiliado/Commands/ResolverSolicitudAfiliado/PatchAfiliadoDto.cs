namespace CleanArchitecture.Application.Features.Afiliado.Commands.ResolverSolicitudAfiliado;

public class PatchAfiliadoDto
{
    public int EstadoSolicitudId { get; set; }
    public DateTime? FechaIngreso { get; set; }
    public DateTime? FechaEgreso { get; set; }
}
