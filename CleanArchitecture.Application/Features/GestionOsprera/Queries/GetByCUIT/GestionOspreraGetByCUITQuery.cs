using MediatR;

namespace CleanArchitecture.Application.Features.GestionOsprera.Queries.GetByPersona;

public class GestionOspreraGetByCUITQuery : IRequest<GestionOspreraVm>
{    
    public long CUIT { get; set; }
}
