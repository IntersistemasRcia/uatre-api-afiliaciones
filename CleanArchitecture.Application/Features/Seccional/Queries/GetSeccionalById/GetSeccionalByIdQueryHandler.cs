using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Specification.Implements;
using CleanArchitecture.Application.Specification;
using MediatR;

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

        if (entidad != null)
        {
            var refDelegacion = await _unitOfWork.RefRepository.GetDelegacionById(entidad.RefDelegacionId);

            entidad.RefDelegacionDescripcion = refDelegacion?.Nombre ?? string.Empty;
        }
        
        return _mapper.Map<SeccionalVm>(entidad);
    }
}
