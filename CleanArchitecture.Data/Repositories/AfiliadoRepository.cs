using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

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

            switch (afiliado!.EstadoSolicitudId)
            {
                case 1:
                    var nroAfiliado = await context.Afiliados!.OrderByDescending(x => x.NroAfiliado).Take(1)!.Select(x => x.NroAfiliado).FirstOrDefaultAsync();
                    model.Operations[1].value = DateTime.Now.Date;
                    model.Operations[2].value = nroAfiliado + 1;
                    break;

                case 2:
                    model.Operations[1].value = DateTime.Now.Date;
                    model.Operations[2].value = afiliado.NroAfiliado;
                    break;

                default:
                    break;
            }

            model.ApplyTo(afiliado);
            return await context.SaveChangesAsync();
        }
    }
}
