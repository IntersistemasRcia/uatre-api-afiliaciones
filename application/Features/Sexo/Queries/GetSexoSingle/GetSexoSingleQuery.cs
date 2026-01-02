using MediatR;

namespace CleanArchitecture.Application.Features.Sexo.Queries.GetSexoSingle
{
    public class GetSexoSingleQuery : IRequest<SexoVm>
    {
        public int Id { get; set; }

        public GetSexoSingleQuery(int pId)
        {
            Id = pId;
        }
    }
}
