using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Common.Exceptions;
using MediatR;
namespace CleanArchitecture.Application.Features.Afiliado.Queries.GetAfiliadoById;

public class GetAfiliadoByIdQueryHandler : IRequestHandler<GetAfiliadoByIdQuery, AfiliadoVm>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAfiliadoByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<AfiliadoVm> Handle(GetAfiliadoByIdQuery request, CancellationToken cancellationToken)
    {
        var entidad = await _unitOfWork.Repository<Domain.Afiliado>().GetByIdAsync(request.Id);
        if (entidad is null)
        {
            throw new NotFoundException(nameof(Domain.Afiliado), request.Id);
        }

        return _mapper.Map<AfiliadoVm>(entidad);
    }
}
