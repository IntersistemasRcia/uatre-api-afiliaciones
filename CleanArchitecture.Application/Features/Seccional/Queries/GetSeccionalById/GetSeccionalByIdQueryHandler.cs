using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Specification.Implements;
using CleanArchitecture.Application.Specification;
using MediatR;
using CleanArchitecture.Common.Exceptions;

namespace CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalById;

public class GetSeccionalByIdQueryHandler : IRequestHandler<GetSeccionalByIdQuery, SeccionalVm>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetSeccionalByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<SeccionalVm> Handle(GetSeccionalByIdQuery request, CancellationToken cancellationToken)
    {
        var spec = new SeccionalSpecification(request.Id);
        var entidad = await _unitOfWork.Repository<Domain.Seccional>().GetOneWithSpecsAsync(spec);
        if (entidad == null)
        {
            throw new NotFoundException(nameof(Domain.Seccional), request.Id);
        }
        
        var data = _mapper.Map<SeccionalVm>(entidad);

        var refDelegacion = await _unitOfWork.RefRepository.GetDelegacionById(entidad.RefDelegacionId);

        data.RefDelegacionDescripcion = refDelegacion?.Nombre ?? string.Empty;

        return data;
    }
}
