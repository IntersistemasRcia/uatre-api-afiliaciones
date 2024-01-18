using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Contracts.Persistence;

public interface IRefLocalidadRepository
{
    Task<bool> ExisteRefLocalidadCodPostal(int codPostal);    
}
