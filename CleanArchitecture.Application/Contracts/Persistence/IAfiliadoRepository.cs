using CleanArchitecture.Application.Features.Afiliado.Commands.PatchAfiliado;
using CleanArchitecture.Domain;
using Microsoft.AspNetCore.JsonPatch;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IAfiliadoRepository : IAsyncRepository<Afiliado>
    {
        Task<int> PatchEntityAsync(int id, JsonPatchDocument model);
        Task<IReadOnlyCollection<Afiliado>> VerificarAutoridadSeccional(IReadOnlyCollection<Afiliado> afiliados);
    }
}
