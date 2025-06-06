using MediatR;

namespace CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresasDetalle.Queries.GetByEmpresaId;

public class GetByEmpresaIdCommand : IRequest<IReadOnlyCollection<SolicitudAfiliacionEmpresasDetalleVm>>
{
    public int SolicitudAfiliacionEmpresasId { get; set; }
}
