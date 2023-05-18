using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Commom;
using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using System.Collections;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AfiliacionesDbContext context;
        private readonly UATRERefDbContext uatreContext;
        private Hashtable repositories;
        private IConfiguration configuration;
        private IHttpClientFactory httpClientFactory;

        private IRefRepository refRepository;
        private IAfiliadoRepository afiliadoRepository;
        private ISeccionalAutoridadRepository seccionalAutoridadRepository;        

        //Repositorios especiales no se inyectan, de definen x propiedades
        //public IRefRepository RefRepository => refRepository ??= new RefRepository(uatreContext);
        public IAfiliadoRepository AfiliadoRepository => afiliadoRepository ??= new AfiliadoRepository(context, httpClientFactory, configuration, new RefRepository(uatreContext));
        public ISeccionalAutoridadRepository SeccionalAutoridadRepository => seccionalAutoridadRepository ??= new SeccionalAutoridadRepository(configuration, httpClientFactory);

        public UnitOfWork(AfiliacionesDbContext context, IConfiguration configuration, IHttpClientFactory httpClientFactory, UATRERefDbContext uatreContext)
        {
            this.context = context;
            this.configuration = configuration;
            this.httpClientFactory = httpClientFactory;
            this.uatreContext = uatreContext;
        }

        public AfiliacionesDbContext AfiliacionesDbContext => context;
        public UATRERefDbContext UATRERefDbContext => uatreContext;

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
