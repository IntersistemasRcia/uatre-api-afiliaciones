using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface ISexoRepository : IAsyncRepository<Sexo>
    {
        //Task<Sexo> GetSexoById(int pId);
        //Task<IEnumerable<Sexo>> GetSexoAll();
    }
}
