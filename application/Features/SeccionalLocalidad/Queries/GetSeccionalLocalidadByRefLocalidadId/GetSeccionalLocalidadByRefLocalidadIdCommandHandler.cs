using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.Afiliado.Queries;
using CleanArchitecture.Application.Features.Afiliado.Queries.GetAfiliadoByCUIL;
using CleanArchitecture.Application.Models.APIComunes;
using CleanArchitecture.Application.Specification.Implements;
using CleanArchitecture.Common.Exceptions;
using MediatR;

namespace CleanArchitecture.Application.Features.SeccionalLocalidad.Queries.GetSeccionalLocalidadByRefLocalidadId;

public class GetSeccionalLocalidadByRefLocalidadIdCommandHandler : IRequestHandler<GetSeccionalLocalidadByRefLocalidadIdCommand, IReadOnlyCollection<SeccionalLocalidadVm>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetSeccionalLocalidadByRefLocalidadIdCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<SeccionalLocalidadVm>> Handle(GetSeccionalLocalidadByRefLocalidadIdCommand request, CancellationToken cancellationToken)
    {
        var spec = new GetSeccionalLocalidadByRefLocalidadIdSpec(request);
        var list = await _unitOfWork.Repository<Domain.SeccionalLocalidad>().GetAllWithSpecsAsync(spec);

        var data = _mapper.Map<IReadOnlyCollection<SeccionalLocalidadVm>>(list);

        foreach (var sl in data)
        {
            var refDelegacion = sl.RefDelegacionId != 0
                ? await _unitOfWork.RefRepository.GetDelegacionById(sl.RefDelegacionId)
                : null;
            sl.RefDelegacionDescripcion = refDelegacion?.Nombre ?? string.Empty;
        }

        return data;
    }
}
