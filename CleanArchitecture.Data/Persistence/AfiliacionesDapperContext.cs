using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace CleanArchitecture.Infrastructure.Persistence;

public class AfiliacionesDapperContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public AfiliacionesDapperContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new NotImplementedException();
    }

    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
}
