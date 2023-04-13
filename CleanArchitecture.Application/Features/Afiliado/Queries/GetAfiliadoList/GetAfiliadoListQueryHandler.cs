using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Specification;
using CleanArchitecture.Application.Specification.Implements;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Application.Features.Afiliado.Queries.GetAfiliadoList
{
    public class GetAfiliadoListQueryHandler : IRequestHandler<GetAfiliadoListQuery, Pagination<AfiliadoVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public GetAfiliadoListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<Pagination<AfiliadoVm>> Handle(GetAfiliadoListQuery request, CancellationToken cancellationToken)
        {            
            var spec = new AfiliadoSpecification(request);
            var padronList = await _unitOfWork.AfiliadoRepository.GetAllWithSpecsAsync(spec);
            var padronListConMarcaAutoridad = await _unitOfWork.AfiliadoRepository.VerificarAutoridadSeccional(padronList);

            var totalRecords = await _unitOfWork.AfiliadoRepository.CountAsync(new BaseSpecification<Domain.Afiliado>(spec.Criteria));
            var totalPages = Convert.ToInt32(Math.Ceiling(totalRecords / Convert.ToDecimal(request.GetPageSize())));

            var data = _mapper.Map<List<AfiliadoVm>>(padronListConMarcaAutoridad);


            return new Pagination<AfiliadoVm>()
            {
                Index = request.GetPageIndex(),
                Size = request.GetPageSize(),
                Pages = totalPages,
                Count = totalRecords,
                Data = data
            };        
        }
    }
}
