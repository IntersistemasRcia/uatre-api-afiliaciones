using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class SexoRepository : RepositoryBase<Sexo>, ISexoRepository
    {
        public SexoRepository(AfiliacionesDbContext context) : base(context)
        {
        }

        //public async Task<Sexo> GetSexoById(int pId)
        //{
        //    var video = await context.Sexos!.Where(e => e.Id == pId).SingleOrDefaultAsync();
        //    return video!;
        //}

        //public async Task<IEnumerable<Sexo>> GetSexoAll()
        //{
        //    var videos = await context.Sexos!.ToListAsync();

        //    return videos;
        //}
    }
}
