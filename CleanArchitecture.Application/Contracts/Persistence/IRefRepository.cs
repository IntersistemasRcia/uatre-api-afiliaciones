using CleanArchitecture.Application.Models.APIComunes;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IRefRepository
    {
        Task<Empresa> GetEmpresaById(int id);
        Task<RefDelegacion> GetDelegacionById(int id);
    }
}
