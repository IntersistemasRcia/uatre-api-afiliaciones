using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.GestionOsprera.Queries.GetGestionOspreraList;
using CleanArchitecture.Application.Features.Afiliado.Queries;
using CleanArchitecture.Application.Features.GestionOsprera.Queries.GetGestionOspreraList;
using CleanArchitecture.Application.Features.GestionOsprera.Queries.GetGestionOspreraList;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Models.APIComunes;
using CleanArchitecture.Application.Specification;
using CleanArchitecture.Application.Specification.Implements;
using CleanArchitecture.Common.Exceptions;
using CleanArchitecture.Common.Helpers;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Application.Features.GestionOsprera.Queries.GetGestionOspreraList;

public class GetGestionOspreraListQueryHandler : IRequestHandler<GetGestionOspreraListQuery, Pagination<GestionOspreraVm>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public GetGestionOspreraListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _configuration = configuration;
    }
    public async Task<Pagination<GestionOspreraVm>> Handle(GetGestionOspreraListQuery request, CancellationToken cancellationToken)
    {
        var todos = request.AmbitoTodos?.Ids.Count != 0 ? true : false;
        if (todos == false)
        {
            var validator = new GetGestionOspreraListQueryValidator();
            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                throw new BadRequestException(result.Errors.Select(x => x.ErrorMessage).ToList().ToJsonString());
            }
        }

        var spec = new GestionOspreraSpecification(request);
        var padronList = await _unitOfWork.Repository<Domain.GestionOsprera>().GetAllWithSpecsAsync(spec);
        //var padronListConMarcaAutoridad = await _unitOfWork.AfiliadoRepository.VerificarAutoridadSeccional(padronList);

        var totalRecords = await _unitOfWork.Repository<Domain.GestionOsprera>().CountAsync(new BaseSpecification<Domain.GestionOsprera>(spec.Criteria));
        var totalPages = Convert.ToInt32(Math.Ceiling(totalRecords / Convert.ToDecimal(request.GetPageSize())));
        var data = _mapper.Map<List<GestionOspreraVm>>(padronList);


        foreach (var gestion in data)
        {
            var documentacion = await _unitOfWork.RefRepository.GetDocumentacionEntidadById("A", gestion.Id);

            gestion.Documentacion = new List<DocumentacionEntidad>();
            gestion.Documentacion = (List<DocumentacionEntidad>)documentacion;
        }
        return new Pagination<GestionOspreraVm>()
        {
            Index = request.GetPageIndex(),
            Size = request.GetPageSize(),
            Pages = totalPages,
            Count = totalRecords,
            Data = data
        };        
    }
}
