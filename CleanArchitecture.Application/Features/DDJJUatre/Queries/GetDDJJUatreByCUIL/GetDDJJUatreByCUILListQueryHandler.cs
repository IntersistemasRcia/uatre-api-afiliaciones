using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Specification.Implements;
using CleanArchitecture.Domain;
using MediatR;
using System.Text.Json;

namespace CleanArchitecture.Application.Features.DDJJUatre.Queries.GetDDJJUatreByCUIL
{
    public class GetDDJJUatreByCUILListQueryHandler : IRequestHandler<GetDDJJUatreByCUILListQuery, List<DDJJUatreVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;

        public GetDDJJUatreByCUILListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<DDJJUatreVm>> Handle(GetDDJJUatreByCUILListQuery request, CancellationToken cancellationToken)
        {
            var spec = new DDJJUatreSpecification(request);
            var list = await _unitOfWork.Repository<Domain.DDJJUatre>().GetAllWithSpecsAsync(spec);
            var finalList = list.OrderByDescending(x => x.Periodo).Take(12).ToList();
            //var cuites = (
            //    from c in finalList
            //    select new
            //    {
            //        CUIT = c.CUIT
            //    })
            //    .AsEnumerable()
            //    .GroupBy(x => x.CUIT)
            //    .Select(x => x);

            var ddjjuatredto = _mapper.Map<List<DDJJUatreVm>>(finalList);
            foreach (var item in ddjjuatredto)
            {
                //Busco la empresa
                var client = _httpClientFactory.CreateClient("APIComunes");
                var response = await client.GetAsync($"/api/Empresas/GetEmpresaSpecs?CUIT={item.CUIT}");
                if (response.IsSuccessStatusCode)
                {
                    string? jsonString = await response.Content.ReadAsStringAsync();
                    var empresa = JsonSerializer.Deserialize<Empresas>(jsonString);
                    item.Empresa = empresa?.RazonSocial ?? default(string);
                }
                else
                {
                    item.Empresa = "";
                }
            }

            return ddjjuatredto;
        }
    }
}
