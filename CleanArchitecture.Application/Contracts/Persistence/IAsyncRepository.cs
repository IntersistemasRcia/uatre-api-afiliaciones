using CleanArchitecture.Application.Contracts.Specification;
using CleanArchitecture.Domain.Commom;
using Microsoft.AspNetCore.JsonPatch;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : BaseDomainModel
    {
        Task<IReadOnlyList<T>> GetAllAsync();        
        Task<IReadOnlyList<T>> GetAllWithSpecsAsync(ISpecification<T> spec, bool disableTracking = true);
        Task<T?> GetOneWithSpecsAsync(ISpecification<T> spec);
        Task<T> GetByIdAsync (int id);
        Task<T> AddAsync(T Entity);
        Task<T> UpdateAsync(T Entity);
        Task DeleteAsync(T Entity);
        void DarDeBajaAsync(T Entity, JsonPatchDocument model);
        void ReactivarAsync(T Entity, JsonPatchDocument model);
        Task<int> CountAsync(ISpecification<T> spec);
        void PatchAsync(T Entity, JsonPatchDocument model);
    }
}
