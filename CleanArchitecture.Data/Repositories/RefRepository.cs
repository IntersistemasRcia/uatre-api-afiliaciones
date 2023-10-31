using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models.APIComunes;
using CleanArchitecture.Infrastructure.Persistence;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Polly;
using System.Data;
using System.Data.SqlClient;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class RefRepository : IRefRepository
    {
        private readonly UATRERefDbContext _context;
        private IDbConnection _db;

        public RefRepository(UATRERefDbContext context, IConfiguration configuration)
        {
            _db = new SqlConnection(configuration.GetConnectionString("UATRERefConnection"));
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

        public async Task<T> GetById<T>(int id) where T : class
        {
            var entity = await _context.Set<T>().FindAsync(id);
            
            return entity;
        }

        public async Task<T> AddAsync<T>(T Entity) where T : class
        {
            await _context.Set<T>().AddAsync(Entity);
            //await context.SaveChangesAsync();

            return Entity;
        }

        public async Task<T> UpdateAsync<T>(T Entity) where T : class
        {
            _context.Set<T>().Attach(Entity);
            _context.Entry(Entity).State = EntityState.Modified;
            //await context.SaveChangesAsync();

            return Entity;
        }

        public async Task BorrarDocumentacionEntidad(string tipo, int id)
        {
            try
            {
                string SQL = $"DELETE FROM DocumentacionEntidades WHERE EntidadTipo = '{tipo}' AND EntidadId = {id}";
                using (var connection = _db)
                {
                    var affectedRows = connection.Execute(SQL);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
