using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface ISeccionalAutoridadRepository
    {
        Task<IReadOnlyCollection<SeccionalAutoridad>> GetSeccionalAutoridadesBySeccional(int seccionalId, bool soloVigentes = true);
        Task<SeccionalAutoridad> GetSeccionalAutoridadCompletoById(int seccionalAutoridadId);
    }
}
