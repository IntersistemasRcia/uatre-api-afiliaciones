using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models.APIComunes;
using CleanArchitecture.Application.Specification.Implements;
using CleanArchitecture.Common.Exceptions;
using CleanArchitecture.Common.Helpers;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesListSpecs
{
    public class GetSeccionalesListSpecsQueryHandler : IRequestHandler<GetSeccionalesListSpecsQuery, List<SeccionalVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSeccionalesListSpecsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<SeccionalVm>> Handle(GetSeccionalesListSpecsQuery request, CancellationToken cancellationToken)
        {
            var todos = request.Ambitos.FirstOrDefault(x => x.Tipo == "T");
            if (todos == null)
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
            List<Domain.Seccional> returnList = new List<Domain.Seccional>();

            if (todos == null)
            {
                foreach (var ambito in request.Ambitos)
                {
                    switch (ambito.Tipo)
                    {
                        case "P":
                            returnList.AddRange(list.Where(x => x.SeccionalLocalidad.Where(sl => sl.RefLocalidad.ProvinciaId == ambito.Id).Any()).ToList());
                            break;

                        case "D":
                            returnList.AddRange(list.Where(x => x.RefDelegacionId == ambito.Id).ToList());
                            break;

                        case "S":
                            returnList.AddRange(list.Where(x => x.Id == ambito.Id).ToList());
                            break;

                        default:
                            break;
                    }
                }

                foreach (var item in returnList)
                {
                    var refDelegacion = await _unitOfWork.RefRepository.GetDelegacionById(item.RefDelegacionId);

                    item.RefDelegacionDescripcion = refDelegacion?.Nombre ?? string.Empty;
                }
                return _mapper.Map<List<SeccionalVm>>(returnList);
            }
            else
            {
                foreach (var item in returnList)
                {
                    var refDelegacion = await _unitOfWork.RefRepository.GetDelegacionById(item.RefDelegacionId);

                    item.RefDelegacionDescripcion = refDelegacion.Nombre;
                }

                return _mapper.Map<List<SeccionalVm>>(list);
            }
        }
    }
}
