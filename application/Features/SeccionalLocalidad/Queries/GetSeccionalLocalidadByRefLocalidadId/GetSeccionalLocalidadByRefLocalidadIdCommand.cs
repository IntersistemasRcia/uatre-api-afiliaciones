using MediatR;

namespace CleanArchitecture.Application.Features.SeccionalLocalidad.Queries.GetSeccionalLocalidadByRefLocalidadId;

public class GetSeccionalLocalidadByRefLocalidadIdCommand : IRequest<IReadOnlyCollection<SeccionalLocalidadVm>>
{
    public int RefLocalidadId { get; set; }
    public bool SoloActivos { get; set; } = true;
}
