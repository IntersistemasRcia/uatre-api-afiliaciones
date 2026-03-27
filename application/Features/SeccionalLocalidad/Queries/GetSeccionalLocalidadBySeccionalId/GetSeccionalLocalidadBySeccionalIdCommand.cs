using MediatR;

namespace CleanArchitecture.Application.Features.SeccionalLocalidad.Queries.GetSeccionalLocalidadBySeccionalId;

public class GetSeccionalLocalidadBySeccionalIdCommand : IRequest<IReadOnlyCollection<SeccionalLocalidadVm>>
{
    public int SeccionalId { get; set; }
    public bool SoloActivos { get; set; } = true;
}
