using CleanArchitecture.Domain.Commom;
using Microsoft.EntityFrameworkCore.Storage;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        //Repositorios especiales no se inyectan, de definen x propiedades
        IRefRepository RefRepository { get; }
        IAfiliadoRepository AfiliadoRepository { get; }
        ISolicitudAfiliacionEmpresasRepository SolicitudAfiliacionEmpresasRepository { get; }
        ISeccionalAutoridadRepository SeccionalAutoridadRepository { get; }
        ISeccionalRepository SeccionalRepository { get; }
        IDdjjRepository DdjjRepository { get; }
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;
        Task<int> CommitAsync();

        ISQLConnection UatreAfiliaciones { get; }
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
