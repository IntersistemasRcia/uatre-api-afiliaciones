using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Commom;
using CleanArchitecture.Infrastructure.Persistence;
using System.Collections;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AfiliacionesDbContext context;
        private Hashtable repositories;

        private ISexoRepository sexoRepository;
        private IActividadRepository actividadRepository;
        private IPadronRepository padronRepository;

        //Repositorios especiales no se inyectan, de definen x propiedades
        //public IVideoRepository VideoRepository => videoRepository ??= new VideoRepository(context);
        //public IStreamerRepository StreamerRepository => streamerRepository ??= new StreamerRepository(context);
        public ISexoRepository SexoRepository => sexoRepository ??= new SexoRepository(context);
        public IActividadRepository ActividadRepository => actividadRepository ??= new ActividadRepository(context);
        public IPadronRepository PadronRepository => padronRepository ??= new PadronRepository(context);

        public UnitOfWork(AfiliacionesDbContext context)
        {
            this.context = context;
        }

        public AfiliacionesDbContext StreamerDbContext => context;

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
            if (repositories == null)
            {
                repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), context);
                repositories.Add(type, repositoryInstance);
            }

            return (IAsyncRepository<TEntity>)repositories[type];
        }
    }
}
