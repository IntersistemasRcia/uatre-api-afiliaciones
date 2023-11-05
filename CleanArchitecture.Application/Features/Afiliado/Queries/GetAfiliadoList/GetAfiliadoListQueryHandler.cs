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
using System.Collections.Generic;

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
            var todos = request.Ambitos.FirstOrDefault(x => x.Tipo == "T");
            if (todos == null)
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

            //List<Domain.Seccional> returnList = new List<Domain.Seccional>();
            List<Domain.Afiliado> returnList = new List<Domain.Afiliado>();

            if (todos == null)
            {
                foreach (var ambito in request.Ambitos)
                {
                    switch (ambito.Tipo)
                    {
                        case "P":
                            returnList.AddRange(padronListConMarcaAutoridad.Where(x => x.Seccional.SeccionalLocalidad.Where(sl => sl.RefLocalidad.ProvinciaId == ambito.Id).Any()).ToList());
                            break;

                        case "D":
                            returnList.AddRange(padronListConMarcaAutoridad.Where(x => x.Seccional.RefDelegacionId == ambito.Id).ToList());
                            break;

                        case "S":
                            returnList.AddRange(padronListConMarcaAutoridad.Where(x => x.Seccional.Id == ambito.Id).ToList());
                            break;

                        default:
                            break;
                    }
                }
            }
            else
            {
                returnList.AddRange(padronListConMarcaAutoridad);
            }

            foreach (var afiliado in padronList)
            {
                
            }

            var totalRecords = returnList.Count; //await _unitOfWork.Repository<Domain.Afiliado>().CountAsync(new BaseSpecification<Domain.Afiliado>(spec.Criteria));
            var totalPages = Convert.ToInt32(Math.Ceiling(totalRecords / Convert.ToDecimal(request.GetPageSize())));    
            var data = _mapper.Map<List<AfiliadoVm>>(padronListConMarcaAutoridad);

            foreach (var afiliado in data)
            {
                var documentacion = await _unitOfWork.RefRepository.GetDocumentacionEntidadById("A", afiliado.Id);

                afiliado.Documentacion = new List<DocumentacionEntidad>();
                afiliado.Documentacion = (List<DocumentacionEntidad>)documentacion;
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
}
