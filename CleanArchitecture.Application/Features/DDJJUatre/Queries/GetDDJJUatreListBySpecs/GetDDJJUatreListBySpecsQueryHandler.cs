using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.Afiliado.Queries;
using CleanArchitecture.Application.Features.Afiliado.Queries.GetAfiliadoByCUIL;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Specification;
using CleanArchitecture.Application.Specification.Implements;
using CleanArchitecture.Domain;
using MediatR;
using System.Text.Json;

namespace CleanArchitecture.Application.Features.DDJJUatre.Queries.GetDDJJUatreByCUIL
{
    public class GetDDJJUatreListBySpecsQueryHandler : IRequestHandler<GetDDJJUatreListBySpecsQuery, Pagination<DDJJUatreVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;

        public GetDDJJUatreListBySpecsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<Pagination<DDJJUatreVm>> Handle(GetDDJJUatreListBySpecsQuery request, CancellationToken cancellationToken)
        {
            if (request.CUIL.HasValue && !request.CUIT.HasValue)
            {
                var spec = new DDJJUatreSpecification(request);
                var list = await _unitOfWork.Repository<Domain.DDJJUatre>().GetAllWithSpecsAsync(spec);
                //var finalList = list.OrderByDescending(x => x.Periodo).Take(12).ToList();
                //var cuites = (
                //    from c in finalList
                //    select new
                //    {
                //        CUIT = c.CUIT
                //    })
                //    .AsEnumerable()
                //    .GroupBy(x => x.CUIT)
                //    .Select(x => x);
                var totalRecords = await _unitOfWork.Repository<Domain.DDJJUatre>().CountAsync(new BaseSpecification<Domain.DDJJUatre>(spec.Criteria));
                var totalPages = Convert.ToInt32(Math.Ceiling(totalRecords / Convert.ToDecimal(request.GetPageSize())));
                
                var data = _mapper.Map<List<DDJJUatreVm>>(list);

                var client = _httpClientFactory.CreateClient("APIComunes");
                foreach (var item in data)
                {
                    //Busco la empresa                    
                    var response = await client.GetAsync($"/api/Empresas/GetEmpresaSpecs?CUIT={item.CUIT}");
                    if (response.IsSuccessStatusCode)
                    {
                        string? jsonString = await response.Content.ReadAsStringAsync();
                        var empresa = JsonSerializer.Deserialize<EmpresaDTO>(jsonString);
                        item.Empresa = empresa?.razonSocial ?? default(string);
                    }
                    else
                    {
                        item.Empresa = "";
                    }
                }

                return new Pagination<DDJJUatreVm>()
                {
                    Index = request.GetPageIndex(),
                    Size = request.GetPageSize(),
                    Pages = totalPages,
                    Count = totalRecords,
                    Data = data
                };
            }      
            else
            {
                var spec = new DDJJUatreSpecification(request);
                var ultimoPeriodo = await _unitOfWork.Repository<Domain.DDJJUatre>().GetAllWithSpecsAsync(spec);

                var newRequest = new GetDDJJUatreListBySpecsQuery(){ CUIT = request.CUIT, Periodo = ultimoPeriodo[0].Periodo, TakeRecords = null, PageSize = request.PageSize };
                var newSpec = new DDJJUatreSpecification(newRequest);
                var list = await _unitOfWork.Repository<Domain.DDJJUatre>().GetAllWithSpecsAsync(newSpec);

                var totalRecords = await _unitOfWork.Repository<Domain.DDJJUatre>().CountAsync(new BaseSpecification<Domain.DDJJUatre>(newSpec.Criteria));
                var totalPages = Convert.ToInt32(Math.Ceiling(totalRecords / Convert.ToDecimal(request.GetPageSize())));

                var data = _mapper.Map<List<DDJJUatreVm>>(list);

                foreach (var item in data)
                {
                    var specAfiliado = new AfiliadoByCUILSpecification(new GetAfiliadoByCUILQuery() { CUIL = Convert.ToInt64(item.CUIL), IncludeRelatedTables = false });
                    var afiliado = await _unitOfWork.Repository<Domain.Afiliado>().GetAllWithSpecsAsync(specAfiliado);
                    item.AfiliadoNombre = afiliado.Count > 0 ? afiliado[0].Nombre : "";
                }

                return new Pagination<DDJJUatreVm>()
                {
                    Index = request.GetPageIndex(),
                    Size = request.GetPageSize(),
                    Pages = totalPages,
                    Count = totalRecords,
                    Data = data
                };
            }
        }
    }
}
