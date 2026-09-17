using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Commom;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Persistence.SQLConnections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System.Collections;
using System.Data;
using System.Data.Common;

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
        private ISolicitudAfiliacionEmpresasRepository solicitudAfiliacionEmpresasRepository;
        private ISeccionalAutoridadRepository seccionalAutoridadRepository;
        private ISeccionalRepository _seccionalRepository;
        private IDdjjRepository ddjjRepository;

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
        public ISolicitudAfiliacionEmpresasRepository SolicitudAfiliacionEmpresasRepository => solicitudAfiliacionEmpresasRepository ??= new SolicitudAfiliacionEmpresasRepository(context, dapperContext);
        public ISeccionalAutoridadRepository SeccionalAutoridadRepository => seccionalAutoridadRepository ??= new SeccionalAutoridadRepository(configuration);
        public ISeccionalRepository SeccionalRepository => _seccionalRepository ??= new SeccionalRepository(context, dapperContext);
        public ISQLConnection UatreAfiliaciones => uatreAfiliaciones ??= new UatreAfiliacionesConnection(configuration);
        public IDdjjRepository DdjjRepository => ddjjRepository ??= new DdjjRepository(configuration, serviceProvider);
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

        public async Task<IDbContextTransaction> BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            // Evitamos llamar a BeginTransactionAsync(isolationLevel) que no existe en todas las versiones de EF.
            // Abrimos la conexión y creamos la transacción a nivel de ADO.NET, luego la asociamos al DbContext.
            var connection = context.Database.GetDbConnection();
            if (connection.State != ConnectionState.Open)
                await connection.OpenAsync();

            // Crear transacción ADO.NET con nivel de aislamiento solicitado
            DbTransaction dbTransaction = connection.BeginTransaction(isolationLevel);

            // Asociar la transacción al DbContext para que EF la use
            context.Database.UseTransaction(dbTransaction);

            // CurrentTransaction ahora estará presente y lo devolvemos
            return context.Database.CurrentTransaction!;
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
