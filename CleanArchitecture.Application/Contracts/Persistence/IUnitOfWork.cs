using CleanArchitecture.Domain.Commom;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        //Repositorios especiales no se inyectan, de definen x propiedades
        ISexoRepository SexoRepository { get; }
        IActividadRepository ActividadRepository { get; }
        IPadronRepository PadronRepository { get; }
        ISeccionalRepository SeccionalRepository { get; }
        IPuestoRepository PuestoRepository { get; }
        IProvinciaRepository ProvinciaRepository { get; }

        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;
        Task<int> CommitAsync();
    }
}
