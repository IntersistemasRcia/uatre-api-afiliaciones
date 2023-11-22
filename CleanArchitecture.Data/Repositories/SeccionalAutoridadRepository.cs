using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Models.APIComunes;
using CleanArchitecture.Domain;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class SeccionalAutoridadRepository : ISeccionalAutoridadRepository
    {
        private IDbConnection _db;
        private IHttpClientFactory _httpClientFactory;

        public SeccionalAutoridadRepository(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            _httpClientFactory = httpClientFactory;
        }
       
        public async Task<IReadOnlyCollection<SeccionalAutoridad>> GetSeccionalAutoridadesBySeccional(int seccionalId, bool soloVigentes, bool soloActivos)
        {
            string SQL = $"SELECT SA.*, A.*, S.* FROM SeccionalAutoridades SA INNER JOIN Afiliados A ON SA.AfiliadoId = A.Id INNER JOIN Seccionales S ON SA.SeccionalId = S.Id WHERE SA.SeccionalId = {seccionalId}";

            var seccionalAutoridadDic = new Dictionary<int, SeccionalAutoridad>();
            var seccionalAutoridades = await _db.QueryAsync<SeccionalAutoridad, Afiliado, Seccional, SeccionalAutoridad>(SQL, (sa, a, s) =>
            {
                if (!seccionalAutoridadDic.TryGetValue(sa.Id, out var currentSeccionalAutoridad))
                {                    
                    currentSeccionalAutoridad = sa;
                    seccionalAutoridadDic.Add(currentSeccionalAutoridad.Id, currentSeccionalAutoridad);                                     
                }

                //currentSeccionalAutoridad.RefCargosDescripcion;
                currentSeccionalAutoridad.Seccional = s;
                currentSeccionalAutoridad.AfiliadoNombre = a.Nombre;
                currentSeccionalAutoridad.AfiliadoNumero = a.NroAfiliado;

                return currentSeccionalAutoridad;
            });

            if (soloVigentes == true)
            {
                seccionalAutoridades = seccionalAutoridades.Where(x => x.FechaVigenciaDesde <= DateTime.Now.Date && x.FechaVigenciaHasta >= DateTime.Now.Date).ToList();
            }

            if (soloActivos)
            {
                seccionalAutoridades = seccionalAutoridades.Where(x => x.DeletedDate == null).ToList();
            }

            if (seccionalAutoridades.Any())
            {
                var client = _httpClientFactory.CreateClient("APIComunes");
                var response = await client.GetAsync($"/api/RefCargo/GetAll");
                if (response.IsSuccessStatusCode)
                {
                    string? jsonString = await response.Content.ReadAsStringAsync();
                    var refCargos = JsonSerializer.Deserialize<IReadOnlyCollection<APIRefCargoResponse>>(jsonString);
                    foreach (var item in seccionalAutoridades)
                    {
                        item.RefCargosDescripcion = refCargos!.FirstOrDefault(x => x.id == item.RefCargosId)!.cargo;
                    }
                }                    
            }            

            return (IReadOnlyCollection<SeccionalAutoridad>)seccionalAutoridades;
        }

        public async Task<SeccionalAutoridad> GetSeccionalAutoridadCompletoById(int seccionalAutoridadId)
        {
            string SQL = $"SELECT * FROM SeccionalAutoridades WHERE Id = {seccionalAutoridadId}";
            var seccionalAutoridad = await _db.QuerySingleAsync<SeccionalAutoridad>(SQL);

            SQL = $"SELECT * FROM Afiliados WHERE Id = {seccionalAutoridad.AfiliadoId}";
            var afiliado = await _db.QuerySingleAsync<Afiliado>(SQL);

            SQL = $"SELECT * FROM Seccionales WHERE Id = {seccionalAutoridad.SeccionalId}";
            var seccional = await _db.QuerySingleAsync<Seccional>(SQL);

            //asigno las properties del bounded context
            seccionalAutoridad.Seccional = seccional;
            seccionalAutoridad.AfiliadoNombre = afiliado.Nombre;
            seccionalAutoridad.AfiliadoNumero = afiliado.NroAfiliado;

            var client = _httpClientFactory.CreateClient("APIComunes");
            var response = await client.GetAsync($"/api/RefCargo/GetById?Id={seccionalAutoridad.RefCargosId}");
            if (response.IsSuccessStatusCode)
            {
                string? jsonString = await response.Content.ReadAsStringAsync();
                var refCargo = JsonSerializer.Deserialize<APIRefCargoResponse>(jsonString);
                seccionalAutoridad.RefCargosDescripcion = refCargo!.cargo;
            }

            return seccionalAutoridad;
        }
    }
}
