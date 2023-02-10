using MediatR;

namespace CleanArchitecture.Application.Features.DDJJUatre.Queries.GetDDJJUatreByCUIL
{
    public class GetDDJJUatreByCUILListQuery : IRequest<List<DDJJUatreVm>>
    {
        public double CUIL { get; set; }
        public GetDDJJUatreByCUILListQuery()
        {

        }
    }
}
