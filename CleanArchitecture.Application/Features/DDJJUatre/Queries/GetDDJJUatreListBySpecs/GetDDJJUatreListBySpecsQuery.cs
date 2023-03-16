using CleanArchitecture.Application.Models;
using MediatR;

namespace CleanArchitecture.Application.Features.DDJJUatre.Queries.GetDDJJUatreByCUIL
{
    public class GetDDJJUatreListBySpecsQuery : IRequest<Pagination<DDJJUatreVm>>
    {
        private int _pageIndex { get; set; } = 1;
        private const int maxPageSize = 50;
        private int _pageSize = 50;

        public double? CUIL { get; set; }
        public double? CUIT { get; set; }
        public int? Periodo { get; set; }

        public string? Sort { get; set; }
        public int? TakeRecords { get; set; }
        public int PageIndex
        {
            get => _pageIndex;
            set => _pageIndex = value;
        }

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value >= maxPageSize ? maxPageSize : value;
        }

        public GetDDJJUatreListBySpecsQuery()
        {

        }
        public int GetPageIndex() { return _pageIndex; }
        public int GetPageSize() { return _pageSize; }
    }
}
