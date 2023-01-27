using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class SeccionalRepository : RepositoryBase<Seccional>, ISeccionalRepository
    {
        public SeccionalRepository(AfiliacionesDbContext context) : base(context)
        {
        }
    }
}
