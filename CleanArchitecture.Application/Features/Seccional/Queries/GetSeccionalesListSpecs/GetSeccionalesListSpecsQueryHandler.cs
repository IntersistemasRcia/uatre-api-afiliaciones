using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.Afiliado.Queries;
using CleanArchitecture.Application.Features.SeccionalLocalidad.Queries;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Models.APIComunes;
using CleanArchitecture.Application.Specification;
using CleanArchitecture.Application.Specification.Implements;
using CleanArchitecture.Common.Exceptions;
using CleanArchitecture.Common.Helpers;
using MediatR;

namespace CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesListSpecs;

public class GetSeccionalesListSpecsQueryHandler : IRequestHandler<GetSeccionalesListSpecsQuery, Pagination<SeccionalVm>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetSeccionalesListSpecsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<Pagination<SeccionalVm>> Handle(GetSeccionalesListSpecsQuery request, CancellationToken cancellationToken)
    {
        var todos = request.AmbitoTodos != null ? true : false;
        if (!todos)
        {
            var validator = new GetSeccionalesListSpecsQueryValidator();
            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                throw new BadRequestException(result.Errors.Select(x => x.ErrorMessage).ToList().ToJsonString());
            }
        }

        var spec = new SeccionalSpecification(request);
        var list = await _unitOfWork.Repository<Domain.Seccional>().GetAllWithSpecsAsync(spec);                

        var totalRecords = await _unitOfWork.Repository<Domain.Seccional>().CountAsync(new BaseSpecification<Domain.Seccional>(spec.Criteria));
        var totalPages = Convert.ToInt32(Math.Ceiling(totalRecords / Convert.ToDecimal(request.GetPageSize())));
        var data = _mapper.Map<List<SeccionalVm>>(list);

        foreach (var item in data)
        {            
            var refDelegacion = await _unitOfWork.RefRepository.GetDelegacionById(item.RefDelegacionId);

            item.RefDelegacionDescripcion = refDelegacion?.Nombre ?? string.Empty;
        }

        return new Pagination<SeccionalVm>()
        {
            Index = request.GetPageIndex(),
            Size = request.GetPageSize(),
            Pages = totalPages,
            Count = totalRecords,
            Data = data
        };
    }
}
