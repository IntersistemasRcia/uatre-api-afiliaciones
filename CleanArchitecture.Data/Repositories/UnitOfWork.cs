using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Commom;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Persistence.SQLConnections;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections;
using System.Data.SqlClient;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AfiliacionesDbContext context;
        private readonly AfiliacionesDapperContext dapperContext;
        private Hashtable repositories;
        private IConfiguration configuration;
        private IHttpClientFactory httpClientFactory;
        private readonly IServiceProvider serviceProvider;
        private ISQLConnection? uatreAfiliaciones;

        private IRefRepository _refRepository;
        private IAfiliadoRepository afiliadoRepository;
        private ISeccionalAutoridadRepository seccionalAutoridadRepository;
        private ISeccionalRepository _seccionalRepository;        

        public UnitOfWork(AfiliacionesDbContext context,
            IConfiguration configuration,
            IHttpClientFactory httpClientFactory,
            AfiliacionesDapperContext dapperContext,
            IServiceProvider serviceProvider)
        {
            this.context = context;
            this.configuration = configuration;
            this.httpClientFactory = httpClientFactory;
            this.dapperContext = dapperContext;
            this.serviceProvider = serviceProvider;
        }

        //Repositorios especiales no se inyectan, de definen x propiedades
        public IRefRepository RefRepository => _refRepository ??= new RefRepository(configuration, serviceProvider);
        public IAfiliadoRepository AfiliadoRepository => afiliadoRepository ??= new AfiliadoRepository(context, httpClientFactory, configuration, new RefRepository(configuration, serviceProvider));
        public ISeccionalAutoridadRepository SeccionalAutoridadRepository => seccionalAutoridadRepository ??= new SeccionalAutoridadRepository(configuration, httpClientFactory);
        public ISeccionalRepository SeccionalRepository => _seccionalRepository ??= new SeccionalRepository(context, dapperContext);
        public ISQLConnection UatreAfiliaciones => uatreAfiliaciones ??= new UatreAfiliacionesConnection(configuration);
        public AfiliacionesDbContext AfiliacionesDbContext => context;
        public AfiliacionesDapperContext AfiliacionesDapperContext => dapperContext;

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
