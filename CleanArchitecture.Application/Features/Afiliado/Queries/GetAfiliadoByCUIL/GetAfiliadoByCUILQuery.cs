using MediatR;

namespace CleanArchitecture.Application.Features.Afiliado.Queries.GetAfiliadoByCUIL
{
    public class GetAfiliadoByCUILQuery : IRequest<AfiliadoVm>
    {
        public Int64 CUIL { get; set; }
        public GetAfiliadoByCUILQuery()
        {

        }
    }
}
