using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Common.Exceptions;
using MediatR;

namespace CleanArchitecture.Application.Features.RefLocalidad.Queries.GetRefLocalidadById;

public class GetRefLocalidadByIdQueryHandler : IRequestHandler<GetRefLocalidadByIdQuery, RefLocalidadVm>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetRefLocalidadByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<RefLocalidadVm> Handle(GetRefLocalidadByIdQuery request, CancellationToken cancellationToken)
    {
        var entidad = await _unitOfWork.Repository<Domain.RefLocalidad>().GetByIdAsync(request.Id);
        if (entidad is null)
        {
            throw new NotFoundException(nameof(Domain.RefLocalidad), request.Id);
        }

        return _mapper.Map<RefLocalidadVm>(entidad);
    }
}
