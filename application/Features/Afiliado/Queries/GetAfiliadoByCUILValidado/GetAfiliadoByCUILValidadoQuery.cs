using MediatR;

namespace CleanArchitecture.Application.Features.Afiliado.Queries.GetAfiliadoByCUILValidado
{
    public class GetAfiliadoByCUILValidadoQuery : IRequest<AfiliadoVm>
    {
        public Int64 CUIL { get; set; }
        public bool IncludeRelatedTables { get; set; } = true;
        public GetAfiliadoByCUILValidadoQuery()
        {

        }
    }
}
