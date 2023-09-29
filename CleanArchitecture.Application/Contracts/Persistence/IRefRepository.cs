using CleanArchitecture.Application.Models.APIComunes;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IRefRepository
    {
        Task<Empresa> GetEmpresaById(int id);
        Task<RefDelegacion> GetDelegacionById(int id);
        void AgregarDocumentacionEntidad(ICollection<DocumentacionEntidad> documentacionEntidad, string entidadTipo, int entidadId);
        Task<IReadOnlyCollection<DocumentacionEntidad>> GetDocumentacionEntidadById(string tipoEntidad, int entidadId);
    }
}
