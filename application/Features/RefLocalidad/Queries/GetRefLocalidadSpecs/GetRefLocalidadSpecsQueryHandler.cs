using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Specification;
using CleanArchitecture.Application.Specification.Implements;
using MediatR;

namespace CleanArchitecture.Application.Features.RefLocalidad.Queries.GetRefLocalidadSpecs
{
    public class GetRefLocalidadSpecsQueryHandler : IRequestHandler<GetRefLocalidadSpecsQuery, IReadOnlyList<RefLocalidadVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetRefLocalidadSpecsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<RefLocalidadVm>> Handle(GetRefLocalidadSpecsQuery request, CancellationToken cancellationToken)
        {
            var spec = new RefLocalidadSpecification(request);
            var list = await _unitOfWork.Repository<Domain.RefLocalidad>().GetAllWithSpecsAsync(spec);

            //var totalRecords = await _unitOfWork.Repository<Domain.RefLocalidad>().CountAsync(new BaseSpecification<Domain.RefLocalidad>(spec.Criteria));
            //var totalPages = Convert.ToInt32(Math.Ceiling(totalRecords / Convert.ToDecimal(request.PageSize)));

            var data = _mapper.Map<List<RefLocalidadVm>>(list);

            //return new Pagination<RefLocalidadVm>()
            //{
            //    Index = request.PageIndex,
            //    Size = request.PageSize,
            //    Pages = totalPages,
            //    Count = totalRecords,
            //    Data = data
            //};

            return data;
        }
    }
}
