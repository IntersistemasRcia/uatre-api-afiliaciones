using MediatR;

namespace CleanArchitecture.Application.Features.DDJJUatre.Queries.GetDDJJUatreByCUIL
{
    public class GetDDJJUatreListBySpecsQuery : IRequest<List<DDJJUatreVm>>
    {
        public double? CUIL { get; set; }
        public double? CUIT { get; set; }
        public int? Periodo { get; set; }

        public string? Sort { get; set; }
        public int? TakeRecords { get; set; }        
        public GetDDJJUatreListBySpecsQuery()
        {

        }
    }
}
