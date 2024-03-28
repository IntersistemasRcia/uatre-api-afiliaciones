using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Models.APIComunes;
using CleanArchitecture.Application.Specification;
using CleanArchitecture.Application.Specification.Implements;
using CleanArchitecture.Common.Exceptions;
using CleanArchitecture.Common.Helpers;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Application.Features.Afiliado.Queries.GetAfiliadoList;

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
        var todos = request.AmbitoTodos?.Ids.Count != 0 ? true : false;
        if (todos == false)
        {
            var validator = new GetAfiliadoListQueryValidator();
            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                throw new BadRequestException(result.Errors.Select(x => x.ErrorMessage).ToList().ToJsonString());
            }
        }

        var spec = new AfiliadoSpecification(request);
        var padronList = await _unitOfWork.AfiliadoRepository.ListarAfiliados(spec);
        var padronListConMarcaAutoridad = await _unitOfWork.AfiliadoRepository.VerificarAutoridadSeccional(padronList);

        var totalRecords = await _unitOfWork.Repository<Domain.Afiliado>().CountAsync(new BaseSpecification<Domain.Afiliado>(spec.Criteria));
        var totalPages = Convert.ToInt32(Math.Ceiling(totalRecords / Convert.ToDecimal(request.GetPageSize())));
        var data = _mapper.Map<List<AfiliadoVm>>(padronListConMarcaAutoridad);

        foreach (var afiliado in data)
        {
            var refMotivoBaja = await _unitOfWork.RefRepository.GetRefMotivoBajaById(afiliado.RefMotivoBajaId);
            afiliado.RefMotivoBajaDescripcion = refMotivoBaja?.Descripcion ?? string.Empty;

            var documentacion = await _unitOfWork.RefRepository.GetDocumentacionEntidadById("A", afiliado.Id);

            afiliado.Documentacion = new List<DocumentacionEntidad>();
            afiliado.Documentacion = (List<DocumentacionEntidad>)documentacion;

            var seccionalAfiliacion = await _unitOfWork.Repository<Domain.Seccional>().GetByIdAsync(afiliado.SeccionalIdSolicitudAfiliacion);
            afiliado.SeccionalDescripcionSolicitudAfiliacion = seccionalAfiliacion?.Descripcion ?? string.Empty;
            afiliado.SeccionalCodigoSolicitudAfiliacion = seccionalAfiliacion?.Codigo ?? string.Empty;

            var DdjjUatre = (await _unitOfWork.DdjjRepository.GetUltimoPeriodoCuilAsync(afiliado.CUIL)) ?? new Models.APIDdjj.DdjjUatre() { Periodo = 0 };
            afiliado.UltimaDDJJPeriodo = DdjjUatre.Periodo;
        }

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
