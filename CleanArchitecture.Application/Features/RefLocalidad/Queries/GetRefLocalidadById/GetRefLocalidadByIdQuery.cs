using MediatR;

namespace CleanArchitecture.Application.Features.RefLocalidad.Queries.GetRefLocalidadById;

public class GetRefLocalidadByIdQuery : IRequest<RefLocalidadVm>
{
    public GetRefLocalidadByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
