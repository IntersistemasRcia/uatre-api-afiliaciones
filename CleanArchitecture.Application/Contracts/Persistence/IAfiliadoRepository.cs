using CleanArchitecture.Application.Contracts.Specification;
using CleanArchitecture.Application.Models.APIComunes;
using CleanArchitecture.Domain;
using Microsoft.AspNetCore.JsonPatch;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IAfiliadoRepository
    {
        Task<SeccionalAutoridad?> VerificarAutoridadSeccional(int id);
        Task CrearAfiliado(Afiliado afiliado, APIEmpresaCreate empresa);
        Task ModificarAfiliado(Afiliado afiliado, APIEmpresaCreate empresa);
        void UpdateDatosAfip(Afiliado afiliado, JsonPatchDocument datosAfipModel);
        int GetNroAfiliado();
    }
}
