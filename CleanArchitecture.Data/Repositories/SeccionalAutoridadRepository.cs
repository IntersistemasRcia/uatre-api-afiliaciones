using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Models.APIComunes;
using CleanArchitecture.Domain;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Text.Json;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class SeccionalAutoridadRepository : ISeccionalAutoridadRepository
    {
        private IDbConnection _db;
        private IDbConnection _dbComunes;

        public SeccionalAutoridadRepository(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
            _dbComunes = new SqlConnection(configuration.GetConnectionString("UATRERefConnection"));
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
                foreach (var item in seccionalAutoridades)
                {
                    var refCargo = await _dbComunes.QueryFirstOrDefaultAsync<RefCargo>("SELECT Id, Cargo, Jerarquia FROM RefCargos WHERE Id = @Id", new { Id = item.RefCargosId });

                    item.RefCargosDescripcion = refCargo?.Cargo ?? string.Empty;
                    item.RefCargosJerarquia = refCargo?.Jerarquia ?? 0;
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

            var refCargo = await _dbComunes.QueryFirstOrDefaultAsync<RefCargo>("SELECT Id, Cargo, Jerarquia FROM RefCargos WHERE Id = @Id", new { Id = seccionalAutoridad.RefCargosId });
            seccionalAutoridad.RefCargosDescripcion = refCargo?.Cargo ?? string.Empty;
            seccionalAutoridad.RefCargosJerarquia = refCargo?.Jerarquia ?? 0;


            return seccionalAutoridad;
        }
    }
}
