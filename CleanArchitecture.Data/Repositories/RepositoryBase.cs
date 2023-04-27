using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Contracts.Specification;
using CleanArchitecture.Common.Exceptions;
using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Commom;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Specification;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : BaseDomainModel
    {
        public AfiliacionesDbContext context;

        public RepositoryBase(AfiliacionesDbContext context)
        {
            this.context = context;
        }

        public async Task<T> AddAsync(T Entity)
        {
            context.Set<T>().Add(Entity);
            //await context.SaveChangesAsync();

            return Entity;
        }

        public async Task<T> UpdateAsync(T Entity)
        {
            context.Set<T>().Attach(Entity);
            context.Entry(Entity).State = EntityState.Modified;
            //await context.SaveChangesAsync();

            return Entity;
        }

        public async Task DeleteAsync(T Entity)
        {
            context.Set<T>().Remove(Entity);
            //await context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllWithSpecsAsync(ISpecification<T> spec, bool disableTracking = true)
        {
            if (disableTracking)
                return await ApplySpecification(spec).AsNoTracking().ToListAsync();

            return await ApplySpecification(spec).ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                throw new NotFoundException(typeof(T).Name, id);
            }

            return entity;
        }        

        //public void AddEntity(T Entity)
        //{
        //    context.Set<T>().Add(Entity);
        //}

        //public void DeleteEntity(T Entity)
        //{
        //    context.Set<T>().Attach(Entity);
        //    context.Entry(Entity).State = EntityState.Modified;
        //}

        //public void UpdateEntity(T Entity)
        //{
        //    context.Set<T>().Remove(Entity);
        //}        

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(context.Set<T>().AsQueryable(), spec);
        }

        public async Task<T> GetOneWithSpecsAsync(ISpecification<T> spec)
        {
            var entity = await ApplySpecification(spec).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new NotFoundException(typeof(T).Name, "No se encontró la Entidad con el Specification indicado");
            }

            return entity;
        }
    }
}
