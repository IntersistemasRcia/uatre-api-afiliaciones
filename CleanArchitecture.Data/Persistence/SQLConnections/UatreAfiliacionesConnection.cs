using CleanArchitecture.Application.Contracts.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CleanArchitecture.Infrastructure.Persistence.SQLConnections;

public class UatreAfiliacionesConnection : ISQLConnection
{
    public SqlConnection SQL { get; init; }

    public UatreAfiliacionesConnection(IConfiguration configuration)
    {
        SQL = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
    }
}
