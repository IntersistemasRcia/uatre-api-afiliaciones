using MediatR;

namespace CleanArchitecture.Application.Features.SeccionalAutoridad.Command.UpdateSeccionalAutoridad;

public class UpdateSeccionalAutoridadCommand : IRequest<int>
{
    public int Id { get; set; }
    public int SeccionalId { get; set; }
    public int AfiliadoId { get; set; }
    public int RefCargosId { get; set; }
    public string? Observaciones { get; set; }
    public DateTime FechaVigenciaDesde { get; set; }
    public DateTime FechaVigenciaHasta { get; set; }
}
