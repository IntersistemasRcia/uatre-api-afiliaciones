using CleanArchitecture.Application.Models.APIComunes;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IRefRepository
    {
        Task<Empresa?> GetEmpresaById(int id);

        Task<RefDelegacion?> GetDelegacionById(int id);

        Task<RefMotivosBaja?> GetRefMotivoBajaById(int id);

        Task AgregarDocumentacionEntidad(ICollection<DocumentacionEntidad> documentacionEntidad, string entidadTipo, int entidadId);

        Task AgregarDocumentacionEntidad(DocumentacionEntidad documentacionEntidad, string entidadTipo, int entidadId);

        Task<IReadOnlyCollection<DocumentacionEntidad>> GetDocumentacionEntidadById(string tipoEntidad, int entidadId);

        Task BorrarDocumentacionEntidad(string tipoEntidad, int idEntidad);
        Task BorrarDocumentacionEntidad(int id);
    }
}
