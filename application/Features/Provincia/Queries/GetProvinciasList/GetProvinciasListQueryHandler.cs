using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Specification.Implements;
using CleanArchitecture.Domain;
using MediatR;

namespace CleanArchitecture.Application.Features.Provincia.Queries.GetProvinciasList
{
    public class GetPuestosListQueryHandler : IRequestHandler<GetProvinciasListQuery, List<ProvinciaVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPuestosListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ProvinciaVm>> Handle(GetProvinciasListQuery request, CancellationToken cancellationToken)
        {
            var spec = new ProvinciasGetAllSpec(request);
            var list = await _unitOfWork.Repository<Domain.Provincia>().GetAllWithSpecsAsync(spec);
            var data = _mapper.Map<List<ProvinciaVm>>(list);
            foreach (var item in data)
            {
                if (item.LocalidadIdPorDefecto > 0)
                {
                    var localidadDefecto = await _unitOfWork.Repository<Domain.RefLocalidad>().GetByIdAsync(item.LocalidadIdPorDefecto);
                    item.LocalidadDescripcionPorDefecto = localidadDefecto?.Nombre ?? "Sin Datos";
                }
                else
                {
                    item.LocalidadDescripcionPorDefecto = "Sin Datos";
                }
            }

            return data;
        }
    }
}
