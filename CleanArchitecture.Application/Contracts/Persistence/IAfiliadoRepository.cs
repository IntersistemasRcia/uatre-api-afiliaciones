using CleanArchitecture.Application.Contracts.Specification;
using CleanArchitecture.Application.Features.Afiliado.Commands.CreateAfiliado;
using CleanArchitecture.Application.Models.APIComunes;
using CleanArchitecture.Domain;
using Microsoft.AspNetCore.JsonPatch;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IAfiliadoRepository// : IAsyncRepository<Afiliado>
    {
        Task ResolverSolicitudAsync(int id, JsonPatchDocument model);
        Task<IReadOnlyCollection<Afiliado>> VerificarAutoridadSeccional(IReadOnlyCollection<Afiliado> afiliados);
        Task<Afiliado> BuscarAfiliadoPorSpecs(ISpecification<Afiliado> spec);
        Task<IReadOnlyCollection<Afiliado>> ListarAfiliados(ISpecification<Afiliado> spec, bool disableTracking = true);
        Task CrearAfiliado(Afiliado afiliado, APIEmpresaCreate empresa);
    }
}
