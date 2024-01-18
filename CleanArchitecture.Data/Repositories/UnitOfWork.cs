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
        private readonly AfiliacionesDapperContext dapperContext;
        private Hashtable repositories;
        private IConfiguration configuration;
        private IHttpClientFactory httpClientFactory;

        private IRefRepository _refRepository;
        private IAfiliadoRepository afiliadoRepository;
        private ISeccionalAutoridadRepository seccionalAutoridadRepository;
        private ISeccionalRepository _seccionalRepository;
        private IRefLocalidadRepository _refLocalidadRepository;

        //Repositorios especiales no se inyectan, de definen x propiedades
        public IRefRepository RefRepository => _refRepository ??= new RefRepository(uatreContext, configuration);
        public IAfiliadoRepository AfiliadoRepository => afiliadoRepository ??= new AfiliadoRepository(context, httpClientFactory, configuration, new RefRepository(uatreContext, configuration));
        public ISeccionalAutoridadRepository SeccionalAutoridadRepository => seccionalAutoridadRepository ??= new SeccionalAutoridadRepository(configuration, httpClientFactory);
        public ISeccionalRepository SeccionalRepository => _seccionalRepository ??= new SeccionalRepository(context, dapperContext);
        public IRefLocalidadRepository RefLocalidadRepository => _refLocalidadRepository ??= new RefLocalidadRepository(dapperContext);

        public UnitOfWork(AfiliacionesDbContext context, 
            IConfiguration configuration, 
            IHttpClientFactory httpClientFactory, 
            UATRERefDbContext uatreContext,
            AfiliacionesDapperContext dapperContext)
        {
            this.context = context;
            this.configuration = configuration;
            this.httpClientFactory = httpClientFactory;
            this.uatreContext = uatreContext;
            this.dapperContext = dapperContext;
        }

        public AfiliacionesDbContext AfiliacionesDbContext => context;
        public UATRERefDbContext UATRERefDbContext => uatreContext;
        public AfiliacionesDapperContext AfiliacionesDapperContext => dapperContext;

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();            
        }

        public async Task<int> CommitAsyncUatreRefContext()
        {
            return await uatreContext.SaveChangesAsync();
        }

        public async Task<int> CommitAsyncAllContext()
        {
            var t1 = context.SaveChangesAsync();
            var t2 = uatreContext.SaveChangesAsync();

            await Task.WhenAll(t1, t2);
            
            return t1.Result + t2.Result;
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
