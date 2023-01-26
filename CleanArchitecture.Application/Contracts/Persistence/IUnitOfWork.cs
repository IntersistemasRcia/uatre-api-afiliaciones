using CleanArchitecture.Domain.Commom;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        //Repositorios especiales no se inyectan, de definen x propiedades
        //IStreamerRepository StreamerRepository { get; }
        //IVideoRepository VideoRepository { get; }
        ISexoRepository SexoRepository { get; }
        IActividadRepository ActividadRepository { get; }
        IPadronRepository PadronRepository { get; }

        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;
        Task<int> CommitAsync();
    }
}
