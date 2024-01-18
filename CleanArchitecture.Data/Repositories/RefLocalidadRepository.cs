using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Infrastructure.Persistence;
using Dapper;

namespace CleanArchitecture.Infrastructure.Repositories;

public class RefLocalidadRepository : IRefLocalidadRepository
{
    private readonly AfiliacionesDapperContext _context;

    public RefLocalidadRepository(AfiliacionesDapperContext context)
    {
        _context = context;
    }
    public async Task<bool> ExisteRefLocalidadCodPostal(int codPostal)
    {
        var query = "SELECT * FROM RefLocalidades WHERE CodPostal = @CodPostal";
        using (var connection = _context.CreateConnection())
        {
            var refLocalidades = await connection.QueryAsync<Domain.RefLocalidad>(query, new { codPostal });
            return refLocalidades.ToList().Count > 0 ? true : false;
        }
    }
}
