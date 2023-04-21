using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Contracts.Specification;
using CleanArchitecture.Application.Models.APIComunes;
using CleanArchitecture.Common.Exceptions;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Specification;
using Dapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Polly;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using static Dapper.SqlMapper;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class AfiliadoRepository : IAfiliadoRepository
    {
        private IDbConnection _db;
        private IHttpClientFactory _httpClientFactory;
        private AfiliacionesDbContext _context;

        public AfiliadoRepository(AfiliacionesDbContext context, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            _context = context;
        }

        public async Task<int> ResolverSolicitudAsync(int id, JsonPatchDocument model)
        {            
            var afiliado = await _context.Set<Afiliado>().FindAsync(id);

            //switch (afiliado!.EstadoSolicitudId)
            switch (model.Operations[0].value) //Estado enviado
            {
                case 2: //Activo
                    var nroAfiliado = await _context.Afiliados!.OrderByDescending(x => x.NroAfiliado).Take(1)!.Select(x => x.NroAfiliado).FirstOrDefaultAsync();
                    model.Operations[1].value = DateTime.Now.Date;
                    model.Operations[2].value = nroAfiliado + 1;
                    break;

                case 3: //No activo
                    model.Operations[1].value = null;
                    model.Operations[2].value = 0;
                    break;                

                default:
                    break;
            }

            model.ApplyTo(afiliado);
            return await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<Afiliado>> VerificarAutoridadSeccional(IReadOnlyCollection<Afiliado> afiliados)
        {
            foreach (var item in afiliados)
            {
                string SQL = $"SELECT * FROM SeccionalAutoridades WHERE AfiliadoId = {item.Id}";
                var seccionalAutoridades = await _db.QueryAsync<SeccionalAutoridad>(SQL);
                var seccionalAutoridad = seccionalAutoridades?.FirstOrDefault(x => x.FechaVigenciaDesde <= DateTime.Now.Date && x.FechaVigenciaHasta >= DateTime.Now.Date);
                item.SeccionalAutoridadId = seccionalAutoridad != null ? seccionalAutoridad.Id : 0;
            }
            return afiliados;
        }

        public async Task<Afiliado> BuscarAfiliadoPorSpecs(ISpecification<Afiliado> spec)
        {
            Afiliado? afiliado = await ApplySpecification(spec).FirstOrDefaultAsync();

            if (afiliado == null)
            {
                throw new NotFoundException(typeof(Afiliado).Name, "No se encontró Afiliado con el Specification indicado");
            }

            var httpClient = _httpClientFactory.CreateClient("APIComunes");
            var response = await httpClient.GetAsync($"/api/Empresas/GetById?Id={afiliado.EmpresaId}");
            string? jsonString = await response.Content.ReadAsStringAsync();
            var empresa = JsonSerializer.Deserialize<APIEmpresaResponse>(jsonString);

            afiliado.EmpresaDescripcion = empresa?.razonSocial ?? "";
            afiliado.EmpresaCUIT = empresa?.cuit ?? 0;

            return afiliado;
        }

        public async Task<IReadOnlyCollection<Afiliado>> ListarAfiliados(ISpecification<Afiliado> spec, bool disableTracking = true)
        {
            IReadOnlyCollection<Afiliado> list;
            if (disableTracking)
                list = await ApplySpecification(spec).AsNoTracking().ToListAsync();
            else
                list = await ApplySpecification(spec).ToListAsync();

            if (list.Any())
            {
                var idsEmpresa = list.GroupBy(x => x.EmpresaId).Select(x => x.Key).ToList();
                var httpClient = _httpClientFactory.CreateClient("APIComunes");
                var empresas = new List<APIEmpresaResponse>();
                //httpClient.DefaultRequestHeaders.Add("ApiKey", "dad03323-09ae-41f2-8d2f-15f4ddfcecb7");

                StringBuilder builder = new StringBuilder();
                foreach (var id in idsEmpresa)
                {
                    builder.Append(builder.Length == 0 ? $"Id={id}" : $"&Id={id}");
                }

                var response = await httpClient.GetAsync($"/api/Empresas/GetByIds?{builder}");
                if (response.IsSuccessStatusCode)
                {
                    string? jsonString = await response.Content.ReadAsStringAsync();
                    var apiEmpresas = JsonSerializer.Deserialize<IEnumerable<APIEmpresaResponse>>(jsonString);
                    empresas.AddRange(apiEmpresas);
                }
                    
                foreach (var afiliado in list)
                {                    
                    afiliado.EmpresaDescripcion = empresas?.Where(x => x.id == afiliado.EmpresaId).Select(x => x.razonSocial).FirstOrDefault() ?? "";
                    afiliado.EmpresaCUIT = empresas?.Where(x => x.id == afiliado.EmpresaId).Select(x => x.cuit).FirstOrDefault() ?? 0;
                }
            }            

            return list;
        }

        private IQueryable<Afiliado> ApplySpecification(ISpecification<Afiliado> spec)
        {
            return SpecificationEvaluator<Afiliado>.GetQuery(_context.Set<Afiliado>().AsQueryable(), spec);
        }

        public async Task CrearAfiliado(Afiliado afiliado, APIEmpresaCreate empresa)
        {
            //Creo la empresa primero
            var httpClient = _httpClientFactory.CreateClient("APIComunes");

            var json = JsonSerializer.Serialize(empresa);
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("/api/Empresas", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new BadRequestException("Error creando Empresa");
            }

            string? jsonString = await response.Content.ReadAsStringAsync();
            int empresaId = JsonSerializer.Deserialize<int>(jsonString);

            afiliado.EmpresaId = empresaId;
            _context.Set<Afiliado>().Add(afiliado);
        }
    }
}
