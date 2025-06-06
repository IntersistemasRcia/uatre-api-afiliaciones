using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresasDetalle.Queries.GetByEmpresaId;

public class GetByEmpresaIdCommandHandler : IRequestHandler<GetByEmpresaIdCommand, IReadOnlyCollection<SolicitudAfiliacionEmpresasDetalleVm>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetByEmpresaIdCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<SolicitudAfiliacionEmpresasDetalleVm>> Handle(GetByEmpresaIdCommand request, CancellationToken cancellationToken)
    {
        var spec = new GetByEmpresaIdSpec(request);
        var list = await _unitOfWork.Repository<Domain.SolicitudAfiliacionEmpresasDetalle>().GetAllWithSpecsAsync(spec);

        var data = _mapper.Map<IReadOnlyCollection<SolicitudAfiliacionEmpresasDetalleVm>>(list);

        return data;
    }
}
