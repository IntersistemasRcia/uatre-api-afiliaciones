using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class PadronRepository : RepositoryBase<Padron>, IPadronRepository
    {
        public PadronRepository(AfiliacionesDbContext context) : base(context)
        {
        }
    }
}
