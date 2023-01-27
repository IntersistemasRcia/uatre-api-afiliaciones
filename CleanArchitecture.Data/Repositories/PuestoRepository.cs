using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class PuestoRepository : RepositoryBase<Puesto>, IPuestoRepository
    {
        public PuestoRepository(AfiliacionesDbContext context) : base(context)
        {
        }
    }
}
