using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;
using Dapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class AfiliadoRepository : RepositoryBase<Afiliado>, IAfiliadoRepository
    {
        private IDbConnection _db;
        private IHttpClientFactory _httpClientFactory;

        public AfiliadoRepository(AfiliacionesDbContext context, IHttpClientFactory httpClientFactory, IConfiguration configuration) : base(context)
        {
            _httpClientFactory = httpClientFactory;
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<int> PatchEntityAsync(int id, JsonPatchDocument model)
        {            
            var afiliado = await context.Set<Afiliado>().FindAsync(id);

            switch (afiliado!.EstadoSolicitudId)
            {
                case 1:
                    var nroAfiliado = await context.Afiliados!.OrderByDescending(x => x.NroAfiliado).Take(1)!.Select(x => x.NroAfiliado).FirstOrDefaultAsync();
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
            return await context.SaveChangesAsync();
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
    }
}
