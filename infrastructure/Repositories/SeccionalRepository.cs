using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;
using Dapper;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class SeccionalRepository : ISeccionalRepository
    {
        private AfiliacionesDbContext _context;
        private AfiliacionesDapperContext _dapperContext;

        public SeccionalRepository(AfiliacionesDbContext context, 
            AfiliacionesDapperContext dapperContext)
        {
            _context = context;
            _dapperContext = dapperContext;
        }

        public async Task CrearSeccional(Seccional seccional)
        {
            try
            {
                await _context.Set<Seccional>().AddAsync(seccional);                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Seccional>? GetFirstSeccionalLocalidadByRefLocalidadId(int refLocalidadId)
        {
            var query = "SELECT * FROM Seccionales WHERE Id IN (SELECT SeccionalId FROM SeccionalesLocalidades WHERE RefLocalidadId = @RefLocalidadId)";
            using (var connection = _dapperContext.CreateConnection())
            {
                var seccionalLocalidades = await connection.QueryAsync<Seccional>(query, new { refLocalidadId });

                return seccionalLocalidades.FirstOrDefault() ?? new Seccional();
            }
        }
    }
}
