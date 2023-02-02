using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class AfiliadoRepository : RepositoryBase<Afiliado>, IAfiliadoRepository
    {
        public AfiliadoRepository(AfiliacionesDbContext context) : base(context)
        {
        }
    }
}
