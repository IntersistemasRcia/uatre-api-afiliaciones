using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Contracts.Specification;
using CleanArchitecture.Application.Models.APIComunes;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Specification;
using Dapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text.Json;

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

        public async Task<int> PatchEntityAsync(int id, JsonPatchDocument model)
        {            
            var afiliado = await _context.Set<Afiliado>().FindAsync(id);

            switch (afiliado!.EstadoSolicitudId)
            {
                case 1:
                    var nroAfiliado = await _context.Afiliados!.OrderByDescending(x => x.NroAfiliado).Take(1)!.Select(x => x.NroAfiliado).FirstOrDefaultAsync();
                    model.Operations[1].value = DateTime.Now.Date;
                    model.Operations[2].value = nroAfiliado + 1;
                    break;

                case 2:
                    model.Operations[1].value = DateTime.Now.Date;
                    model.Operations[2].value = afiliado.NroAfiliado;
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

        public async Task<Afiliado> BuscarAfiliadoPorCUIL(double cuil)
        {
            throw new NotImplementedException();
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
                var httpClient = _httpClientFactory.CreateClient("APIComun");
                //httpClient.DefaultRequestHeaders.Add("ApiKey", "dad03323-09ae-41f2-8d2f-15f4ddfcecb7");

                foreach (var afiliado in list)
                {
                    var response = await httpClient.GetAsync($"/api/Empresas/GetById?Id={afiliado.EmpresaId}");
                    if (response.IsSuccessStatusCode)
                    {
                        string? jsonString = await response.Content.ReadAsStringAsync();
                        var empresa = JsonSerializer.Deserialize<APIEmpresaResponse>(jsonString);

                        afiliado.EmpresaDescripcion = empresa?.razonSocial ?? "";
                        afiliado.EmpresaCUIT = empresa?.cuit ?? 0;
                    }
                }
            }            

            return list;
        }

        private IQueryable<Afiliado> ApplySpecification(ISpecification<Afiliado> spec)
        {
            return SpecificationEvaluator<Afiliado>.GetQuery(_context.Set<Afiliado>().AsQueryable(), spec);
        }
    }
}
