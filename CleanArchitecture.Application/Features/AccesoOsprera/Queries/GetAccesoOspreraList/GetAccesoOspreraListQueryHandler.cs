using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.Afiliado.Queries;
using CleanArchitecture.Application.Features.AccesoOsprera.Queries.GetAccesoOspreraList;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Models.APIComunes;
using CleanArchitecture.Application.Specification;
using CleanArchitecture.Application.Specification.Implements;
using CleanArchitecture.Common.Exceptions;
using CleanArchitecture.Common.Helpers;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Application.Features.AccesoOsprera.Queries.GetAccesoOspreraList;

public class GetAccesoOspreraListQueryHandler : IRequestHandler<GetAccesoOspreraListQuery, Pagination<AccesoOspreraVm>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public GetAccesoOspreraListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _configuration = configuration;
    }
    public async Task<Pagination<AccesoOspreraVm>> Handle(GetAccesoOspreraListQuery request, CancellationToken cancellationToken)
    {
        var todos = request.AmbitoTodos?.Ids.Count != 0 ? true : false;
        if (todos == false)
        {
            var validator = new GetAccesoOspreraListQueryValidator();
            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                throw new BadRequestException(result.Errors.Select(x => x.ErrorMessage).ToList().ToJsonString());
            }
        }

        var spec = new AccesoOspreraSpecification(request);
        var padronList = await _unitOfWork.Repository<Domain.AccesoOsprera>().GetAllWithSpecsAsync(spec);
        //var padronListConMarcaAutoridad = await _unitOfWork.AfiliadoRepository.VerificarAutoridadSeccional(padronList);

        var totalRecords = await _unitOfWork.Repository<Domain.AccesoOsprera>().CountAsync(new BaseSpecification<Domain.AccesoOsprera>(spec.Criteria));
        var totalPages = Convert.ToInt32(Math.Ceiling(totalRecords / Convert.ToDecimal(request.GetPageSize())));
        var data = _mapper.Map<List<AccesoOspreraVm>>(padronList);


        foreach (var gestion in data)
        {
            var documentacion = await _unitOfWork.RefRepository.GetDocumentacionEntidadById("A", gestion.Id);

            gestion.Documentacion = new List<DocumentacionEntidad>();
            gestion.Documentacion = (List<DocumentacionEntidad>)documentacion;
        }
        return new Pagination<AccesoOspreraVm>()
        {
            Index = request.GetPageIndex(),
            Size = request.GetPageSize(),
            Pages = totalPages,
            Count = totalRecords,
            Data = data
        };        
    }
}
