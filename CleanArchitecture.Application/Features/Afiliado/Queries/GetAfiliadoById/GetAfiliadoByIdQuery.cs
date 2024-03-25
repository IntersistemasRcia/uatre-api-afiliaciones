using MediatR;

namespace CleanArchitecture.Application.Features.Afiliado.Queries.GetAfiliadoById;

public class GetAfiliadoByIdQuery : IRequest<AfiliadoVm>
{
    public GetAfiliadoByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
