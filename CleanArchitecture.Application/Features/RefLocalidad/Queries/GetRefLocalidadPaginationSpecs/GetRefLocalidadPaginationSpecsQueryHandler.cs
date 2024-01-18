using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Specification;
using CleanArchitecture.Application.Specification.Implements;
using MediatR;

namespace CleanArchitecture.Application.Features.RefLocalidad.Queries.GetRefLocalidadPaginationSpecs;

public class GetRefLocalidadPaginationSpecsQueryHandler : IRequestHandler<GetRefLocalidadPaginationSpecsQuery, Pagination<RefLocalidadVm>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetRefLocalidadPaginationSpecsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Pagination<RefLocalidadVm>> Handle(GetRefLocalidadPaginationSpecsQuery request, CancellationToken cancellationToken)
    {
        var spec = new GetRefLocalidadPaginationSpecs(request);
        var list = await _unitOfWork.Repository<Domain.RefLocalidad>().GetAllWithSpecsAsync(spec);

        var totalRecords = await _unitOfWork.Repository<Domain.RefLocalidad>().CountAsync(new BaseSpecification<Domain.RefLocalidad>(spec.Criteria));
        var totalPages = Convert.ToInt32(Math.Ceiling(totalRecords / Convert.ToDecimal(request.PageSize)));

        var data = _mapper.Map<List<RefLocalidadVm>>(list);

        foreach (var item in data)
        {
            //Busco el primer dato de SeccionalLocalidad
            var seccional = await _unitOfWork.SeccionalRepository.GetFirstSeccionalLocalidadByRefLocalidadId(item.Id);

            item.SeccionalId = seccional.Id;
            item.SeccionalDescripcion = seccional.Descripcion;
            item.SeccionalCodigo = seccional.Codigo;
        }

        return new Pagination<RefLocalidadVm>()
        {
            Index = request.PageIndex,
            Size = request.PageSize,
            Pages = totalPages,
            Count = totalRecords,
            Data = data
        };
    }
}
