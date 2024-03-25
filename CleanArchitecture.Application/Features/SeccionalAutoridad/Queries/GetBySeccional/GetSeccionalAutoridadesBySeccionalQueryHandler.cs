using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.Application.Features.SeccionalAutoridad.Queries.GetBySeccional
{
    public class GetSeccionalAutoridadesbySeccionalQueryHandler : IRequestHandler<GetSeccionalAutoridadesBySeccionalQuery, IReadOnlyCollection<SeccionalAutoridadResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSeccionalAutoridadesbySeccionalQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IReadOnlyCollection<SeccionalAutoridadResponse>> Handle(GetSeccionalAutoridadesBySeccionalQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork.SeccionalAutoridadRepository.GetSeccionalAutoridadesBySeccional(request.SeccionalId, request.SoloVigentes, request.SoloActivos);

            var data = _mapper.Map<IReadOnlyCollection<SeccionalAutoridadResponse>>(list);
            foreach (var item in data)
            {
                var refCargo = await _unitOfWork.RefRepository.GetRefCargoById(item.RefCargosId);

                item.RefCargosDescripcion = refCargo?.Cargo ?? string.Empty;
                item.RefCargoJerarquia = refCargo?.Jerarquia ?? 0;
            }

            return data;
        }
    }
}
