using CleanArchitecture.Domain.Commom;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        //Repositorios especiales no se inyectan, de definen x propiedades
        IRefRepository RefRepository { get; }
        IAfiliadoRepository AfiliadoRepository { get; }
        ISeccionalAutoridadRepository SeccionalAutoridadRepository { get; }
        ISeccionalRepository SeccionalRepository { get; }
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;
        Task<int> CommitAsync();

        ISQLConnection UatreAfiliaciones { get; }
    }
}
