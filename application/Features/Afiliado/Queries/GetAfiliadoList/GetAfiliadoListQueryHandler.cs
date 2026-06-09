using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesListSpecs;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Models.APIComunes;
using CleanArchitecture.Application.Specification;
using CleanArchitecture.Application.Specification.Implements;
using CleanArchitecture.Common.Exceptions;
using CleanArchitecture.Common.Helpers;
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
        request.AmbitoSeccionalesActivas ??= new Ambito();

        var todos = request.AmbitoTodos?.Ids.Count == 0 || request.AmbitoTodos == null || request.AmbitoSeccionales?.Ids.Count > 0 || request.AmbitoDelegaciones?.Ids.Count > 0 ? false : true;
        if (todos == false)
        {
            var validator = new GetAfiliadoListQueryValidator();
            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                throw new BadRequestException(result.Errors.Select(x => x.ErrorMessage).ToList().ToJsonString());
            }

            List<string> estadosActiva = new List<string>();
            if (request.AmbitoTodos?.Ids.Count > 0 || request.AmbitoTodos != null || (request.IgnorarEstadoSeccional.HasValue && request.IgnorarEstadoSeccional.Value == true))
            {
                estadosActiva.Add("TODOS");
            }
            else
            {
                estadosActiva.AddRange(new List<string> { "NORMALIZADA", "TRANSITORIA", "SIN COMISION" });
            }
            //Filtro las seccionales "inactivas"
            if (request.AmbitoSeccionales != null && request.AmbitoSeccionales.Ids.Count > 0)
            {
                var seccionalesActivas = await _unitOfWork.Repository<Domain.Seccional>().GetAllWithSpecsAsync(new SeccionalConEstadoSpec(request.AmbitoSeccionales, estadosActiva));

                if (seccionalesActivas.Count > 0)
                {
                    request.AmbitoSeccionalesActivas.Ids.AddRange(seccionalesActivas.Select(x => x.Id).ToList());
                }
            }
            else if (request.AmbitoDelegaciones != null && request.AmbitoDelegaciones.Ids.Count > 0)
            {
                var seccionalesActivas = await _unitOfWork.Repository<Domain.Seccional>().GetAllWithSpecsAsync(new SeccionalesDelegacionSpec(request.AmbitoDelegaciones, estadosActiva));

                if (seccionalesActivas.Count > 0)
                {
                    request.AmbitoSeccionalesActivas.Ids.AddRange(seccionalesActivas.Select(x => x.Id).ToList());
                }
            }
        }
        else
        {
            if (request.AmbitoSeccionales != null && request.AmbitoSeccionales.Ids.Count > 0)
            {  
                request.AmbitoSeccionalesActivas.Ids.AddRange(request.AmbitoSeccionales.Ids);
            }
            else if (request.AmbitoDelegaciones != null && request.AmbitoDelegaciones.Ids.Count > 0)
            {
                var seccionales = await _unitOfWork.Repository<Domain.Seccional>().GetAllWithSpecsAsync(new SeccionalesDelegacionSpec(request.AmbitoDelegaciones));

                if (seccionales.Count > 0)
                {
                    request.AmbitoSeccionalesActivas.Ids.AddRange(seccionales.Select(x => x.Id).ToList());
                }
            }
        }

        var spec = new AfiliadoSpecification(request);
        var padronList = await _unitOfWork.Repository<Domain.Afiliado>().GetAllWithSpecsAsync(spec);
        //var padronListConMarcaAutoridad = await _unitOfWork.AfiliadoRepository.VerificarAutoridadSeccional(padronList);

        var totalRecords = await _unitOfWork.Repository<Domain.Afiliado>().CountAsync(new BaseSpecification<Domain.Afiliado>(spec.Criteria));
        var totalPages = Convert.ToInt32(Math.Ceiling(totalRecords / Convert.ToDecimal(request.GetPageSize())));
        var data = _mapper.Map<List<AfiliadoVm>>(padronList);

        foreach (var afiliado in data)
        {
            var empresa = await _unitOfWork.RefRepository.GetEmpresaById(afiliado.EmpresaId);
            afiliado.EmpresaDescripcion = empresa?.RazonSocial ?? "";
            afiliado.EmpresaCUIT = empresa?.CUIT ?? 0;

            afiliado.SeccionalAutoridadId = (await _unitOfWork.AfiliadoRepository.VerificarAutoridadSeccional(afiliado.Id))?.SeccionalId ?? 0;

            var refMotivoBaja = await _unitOfWork.RefRepository.GetRefMotivoBajaById(afiliado.RefMotivoBajaId);
            afiliado.RefMotivoBajaDescripcion = refMotivoBaja?.Descripcion ?? string.Empty;
            afiliado.RefMotivoBajaNoPermitirReactivarAfiliado = refMotivoBaja?.NoPermitirReactivarAfiliado ?? false;

            var documentacion = await _unitOfWork.RefRepository.GetDocumentacionEntidadById("A", afiliado.Id);

            afiliado.Documentacion = new List<DocumentacionEntidad>();
            afiliado.Documentacion = (List<DocumentacionEntidad>)documentacion;

            var seccionalAfiliacion = await _unitOfWork.Repository<Domain.Seccional>().GetByIdAsync(afiliado.SeccionalIdSolicitudAfiliacion);
            afiliado.SeccionalDescripcionSolicitudAfiliacion = seccionalAfiliacion?.Descripcion ?? string.Empty;
            afiliado.SeccionalCodigoSolicitudAfiliacion = seccionalAfiliacion?.Codigo ?? string.Empty;

            var DdjjUatre = (await _unitOfWork.DdjjRepository.GetUltimoPeriodoCuilAsync(afiliado.CUIL)) ?? new Models.APIDdjj.DdjjUatre() { Periodo = 0 };
            afiliado.UltimaDDJJPeriodo = DdjjUatre.Periodo;
            afiliado.CondicionRural = DdjjUatre.CondicionRural;

            var refDelegacion = afiliado.RefDelegacionId != 0
                ? await _unitOfWork.RefRepository.GetDelegacionById(afiliado.RefDelegacionId)
                : null;
            afiliado.RefDelegacionDescripcion = refDelegacion?.Nombre ?? string.Empty;
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
