using CleanArchitecture.Application.Models.APIComunes;
using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface ISeccionalRepository
    {
        Task CrearSeccional(Seccional seccional);
    }
}
