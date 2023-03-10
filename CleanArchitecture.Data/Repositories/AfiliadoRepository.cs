using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Features.Afiliado.Commands.PatchAfiliado;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.AspNetCore.JsonPatch;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class AfiliadoRepository : RepositoryBase<Afiliado>, IAfiliadoRepository
    {
        public AfiliadoRepository(AfiliacionesDbContext context) : base(context)
        {
        }

        public async Task<int> PatchEntityAsync(int id, JsonPatchDocument model)
        {
            var afiliado = await context.Set<Afiliado>().FindAsync(id);
            model.ApplyTo(afiliado);
            return await context.SaveChangesAsync();
        }
    }
}
