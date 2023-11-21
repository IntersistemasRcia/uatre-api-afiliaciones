using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.SeccionalLocalidad.Queries.GetSeccionalLocalidadBySeccionalId;

public class GetSeccionalLocalidadBySeccionalIdCommandHandler : IRequestHandler<GetSeccionalLocalidadBySeccionalIdCommand, IReadOnlyCollection<SeccionalLocalidadVm>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetSeccionalLocalidadBySeccionalIdCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<SeccionalLocalidadVm>> Handle(GetSeccionalLocalidadBySeccionalIdCommand request, CancellationToken cancellationToken)
    {
        var spec = new GetSeccionalLocalidadBySeccionalIdSpec(request);
        var list = await _unitOfWork.Repository<Domain.SeccionalLocalidad>().GetAllWithSpecsAsync(spec);

        var data = _mapper.Map<IReadOnlyCollection<SeccionalLocalidadVm>>(list);

        return data;
    }
}
