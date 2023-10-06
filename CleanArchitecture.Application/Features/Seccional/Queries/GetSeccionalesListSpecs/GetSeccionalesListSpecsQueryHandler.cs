using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Specification.Implements;
using MediatR;

namespace CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesListSpecs
{
    public class GetSeccionalesListSpecsQueryHandler : IRequestHandler<GetSeccionalesListSpecsQuery, List<SeccionalVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSeccionalesListSpecsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<SeccionalVm>> Handle(GetSeccionalesListSpecsQuery request, CancellationToken cancellationToken)
        {
            var spec = new SeccionalSpecification(request);
            var list = await _unitOfWork.Repository<Domain.Seccional>().GetAllWithSpecsAsync(spec);
            if (request.SoloActivos)
            {
                var listActivos = list.Where(x => x.DeletedDate == null).ToList();
                return _mapper.Map<List<SeccionalVm>>(listActivos);
            }

            return _mapper.Map<List<SeccionalVm>>(list);
        }
    }
}
