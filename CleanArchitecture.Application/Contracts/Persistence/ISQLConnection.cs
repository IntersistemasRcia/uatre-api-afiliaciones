using Microsoft.Data.SqlClient;

namespace CleanArchitecture.Application.Contracts.Persistence;

public interface ISQLConnection
{
    public SqlConnection SQL { get; }
}
