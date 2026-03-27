using MediatR;

namespace CleanArchitecture.Application.Features.SeccionalAutoridad.Command.CreateSeccionalAutoridad;

public class CreateSeccionalAutoridadCommand : IRequest<int>
{
    public int SeccionalId { get; set; }
    public int AfiliadoId { get; set; }
    public int RefCargosId { get; set; }
    public string? Observaciones { get; set; }
    public DateTime FechaVigenciaDesde { get; set; }
    public DateTime FechaVigenciaHasta { get; set; }
}
