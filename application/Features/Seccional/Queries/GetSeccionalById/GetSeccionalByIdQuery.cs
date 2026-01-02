using MediatR;

namespace CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalById;

public class GetSeccionalByIdQuery : IRequest<SeccionalVm>
{
    public int Id { get; set; }

    public GetSeccionalByIdQuery(int id)
    {
        Id = id;
    }
}
