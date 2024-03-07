using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Specification.Implements;
using MediatR;

namespace CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesList
{
    public class GetSeccionalesListQueryHandler : IRequestHandler<GetSeccionalesListQuery, List<SeccionalVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSeccionalesListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<SeccionalVm>> Handle(GetSeccionalesListQuery request, CancellationToken cancellationToken)
        {
            var spec = new SeccionalSpecification(request);
            var list = await _unitOfWork.Repository<Domain.Seccional>().GetAllWithSpecsAsync(spec);
            //if (request.SoloActivos)
            //{
            //    var listActivos = list.Where(x => x.DeletedDate == null).ToList();
            //    return _mapper.Map<List<SeccionalVm>>(listActivos);
            //}

            return _mapper.Map<List<SeccionalVm>>(list.OrderBy(x => x.Descripcion));
        }
    }
}
