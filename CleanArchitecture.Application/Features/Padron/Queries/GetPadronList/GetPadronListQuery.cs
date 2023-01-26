using CleanArchitecture.Application.Models;
using MediatR;

namespace CleanArchitecture.Application.Features.Padron.Queries.GetPadronList
{
    public class GetPadronListQuery : IRequest<Pagination<PadronVm>>
    {        
        private int _pageIndex { get; set; } = 1;
        private const int maxPageSize = 50;
        private int _pageSize = 20;

        public int? EstadoSolicitudId { get; set; }
        public string? Sort { get; set; }
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

        public string? Search { get; set; }
        public GetPadronListQuery()
        {
            //Id = pId ?? throw new ArgumentNullException(nameof(pId));
        }

        public int GetPageIndex() { return _pageIndex; }

        public int GetPageSize() { return _pageSize; }
    }
}
