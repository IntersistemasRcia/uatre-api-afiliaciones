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

        public async void AgregarDocumentacionEntidad(ICollection<DocumentacionEntidad> documentacionEntidad, string entidadTipo, int entidadId)
        {
            foreach (var item in documentacionEntidad)
            {
                item.EntidadTipo = entidadTipo;
                item.EntidadId = entidadId;
            }
            
            await _context.Set<DocumentacionEntidad>().AddRangeAsync(documentacionEntidad);

            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<DocumentacionEntidad>> GetDocumentacionEntidadById(string tipoEntidad, int entidadId)
        {
            return await _context.Set<DocumentacionEntidad>().Where(x => x.EntidadTipo == tipoEntidad && x.EntidadId == entidadId).ToListAsync();
        }
    }
}
