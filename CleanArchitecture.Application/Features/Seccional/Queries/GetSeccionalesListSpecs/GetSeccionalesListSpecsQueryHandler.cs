using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Specification.Implements;
using CleanArchitecture.Common.Exceptions;
using CleanArchitecture.Common.Helpers;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;

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
            var validator = new GetSeccionalesListSpecsQueryValidator();
            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                throw new BadRequestException(result.Errors.Select(x => x.ErrorMessage).ToList().ToJsonString());
            }

            var spec = new SeccionalSpecification(request);
            var list = await _unitOfWork.Repository<Domain.Seccional>().GetAllWithSpecsAsync(spec);
            List<Domain.Seccional> returnList = new List<Domain.Seccional>();
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


            return _mapper.Map<List<SeccionalVm>>(returnList);
        }
    }
}
