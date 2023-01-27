using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class ProvinciaRepository : RepositoryBase<Provincia>, IProvinciaRepository
    {
        public ProvinciaRepository(AfiliacionesDbContext context) : base(context)
        {
        }
    }
}
