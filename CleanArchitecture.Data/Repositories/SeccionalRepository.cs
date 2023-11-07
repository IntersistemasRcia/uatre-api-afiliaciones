using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class SeccionalRepository : ISeccionalRepository
    {
        private AfiliacionesDbContext _context;

        public SeccionalRepository(AfiliacionesDbContext context)
        {
            _context = context;
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
    }
}
