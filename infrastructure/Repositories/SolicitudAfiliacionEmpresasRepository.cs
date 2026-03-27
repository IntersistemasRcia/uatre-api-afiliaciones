using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.SolicitudAfiliacionEmpresas.Queries;
using CleanArchitecture.Application.Models.APIComunes;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class SolicitudAfiliacionEmpresasRepository : ISolicitudAfiliacionEmpresasRepository
    {
        private AfiliacionesDbContext _context;
        private AfiliacionesDapperContext _dapperContext;

        public SolicitudAfiliacionEmpresasRepository(AfiliacionesDbContext context,
            AfiliacionesDapperContext dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext;
        }

        public async Task CrearSolicitudAfiliacionEmpresas(SolicitudAfiliacionEmpresas solicitud)
        {
            try
            {
                await _context.Set<SolicitudAfiliacionEmpresas>().AddAsync(solicitud);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<SolicitudAfiliacionEmpresasDetalle>? GetLastDetalleBySolicitudId(int solicitudId)
        {
            var query = "SELECT * FROM SolicitudAfiliacionEmpresasDetalle WHERE Id = @SolicitudId";
            using (var connection = _dapperContext.CreateConnection())
            {
                var detalle = await connection.QueryAsync<SolicitudAfiliacionEmpresasDetalle>(query, new { solicitudId });

                return detalle.FirstOrDefault() ?? new SolicitudAfiliacionEmpresasDetalle();
            }
        }

    }
}
