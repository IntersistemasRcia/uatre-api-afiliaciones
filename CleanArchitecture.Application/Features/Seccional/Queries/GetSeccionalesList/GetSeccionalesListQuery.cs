using CleanArchitecture.Application.Features.Provincia.Queries;
using MediatR;

namespace CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesList
{
    public class GetSeccionalesListQuery : IRequest<List<SeccionalVm>>
    {
        public bool SoloActivos { get; set; } = true;
        public GetSeccionalesListQuery()
        {
            //Id = pId ?? throw new ArgumentNullException(nameof(pId));
        }
    }
}
