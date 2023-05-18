using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models.APIComunes;
using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class RefRepository : IRefRepository
    {
        private readonly UATRERefDbContext _context;
        public RefRepository(UATRERefDbContext context)
        {
            _context = context;
        }

        public async Task<RefDelegacion> GetDelegacionById(int id)
        {
            RefDelegacion? entity = await _context.Set<RefDelegacion>().FirstOrDefaultAsync(x => x.Id == id);

            return entity;
        }

        public async Task<Empresa> GetEmpresaById(int id)
        {
            Empresa? entity = await _context.Set<Empresa>().FirstOrDefaultAsync(x => x.Id == id);

            return entity;
        }
    }
}
