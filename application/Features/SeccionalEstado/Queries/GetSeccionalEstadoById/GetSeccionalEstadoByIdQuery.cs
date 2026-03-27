using CleanArchitecture.Application.Features.SeccionalEstado.Responses;
using MediatR;

namespace CleanArchitecture.Application.Features.SeccionalEstado.Queries.GetSeccionalEstadoById;

public class GetSeccionalEstadoByIdQuery : IRequest<SeccionalEstadoResponse>
{
    public GetSeccionalEstadoByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; private set; }
}
