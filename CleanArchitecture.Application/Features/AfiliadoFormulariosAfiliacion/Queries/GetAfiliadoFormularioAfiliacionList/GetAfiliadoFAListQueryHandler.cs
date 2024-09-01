using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.Afiliado.Queries;
using CleanArchitecture.Application.Features.AfiliadoFormulariosAfiliacion.Queries.GetAfiliadoFormularioAfiliacionList;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Models.APIComunes;
using CleanArchitecture.Application.Specification;
using CleanArchitecture.Application.Specification.Implements;
using CleanArchitecture.Common.Exceptions;
using CleanArchitecture.Common.Helpers;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Application.Features.AfiliadoFormulariosAfiliacion.Queries.GetAfiliadoFormularioAfiliacionList;

public class GetAfiliadoFAListQueryHandler : IRequestHandler<GetAfiliadoFAListQuery, Pagination<AfiliadoFormulariosAfiliacionVm>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public GetAfiliadoFAListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _configuration = configuration;
    }
    public async Task<Pagination<AfiliadoFormulariosAfiliacionVm>> Handle(GetAfiliadoFAListQuery request, CancellationToken cancellationToken)
    {
        var todos = request.AmbitoTodos?.Ids.Count != 0 ? true : false;
        if (todos == false)
        {
            var validator = new GetAfiliadoFAListQueryValidator();
            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                throw new BadRequestException(result.Errors.Select(x => x.ErrorMessage).ToList().ToJsonString());
            }
        }

        var spec = new AfiliadoFASpecification(request);
        var padronList = await _unitOfWork.Repository<Domain.AfiliadoFormularioAfiliacion>().GetAllWithSpecsAsync(spec);
        //var padronListConMarcaAutoridad = await _unitOfWork.AfiliadoRepository.VerificarAutoridadSeccional(padronList);

        var totalRecords = await _unitOfWork.Repository<Domain.AfiliadoFormularioAfiliacion>().CountAsync(new BaseSpecification<Domain.AfiliadoFormularioAfiliacion>(spec.Criteria));
        var totalPages = Convert.ToInt32(Math.Ceiling(totalRecords / Convert.ToDecimal(request.GetPageSize())));
        var data = _mapper.Map<List<AfiliadoFormulariosAfiliacionVm>>(padronList);

        return new Pagination<AfiliadoFormulariosAfiliacionVm>()
        {
            Index = request.GetPageIndex(),
            Size = request.GetPageSize(),
            Pages = totalPages,
            Count = totalRecords,
            Data = data
        };        
    }
}
