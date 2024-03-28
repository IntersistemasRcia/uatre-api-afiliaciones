using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models.APIDdjj;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infrastructure.Repositories;

public class DdjjRepository : IDdjjRepository
{
    private readonly SqlConnection db;
    private readonly IHttpContextAccessor httpContextAccessor;

    public DdjjRepository(IConfiguration configuration, IServiceProvider serviceProvider)
    {
        db = new SqlConnection(configuration.GetConnectionString("UATREDDJJConnection"));
        httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
    }

    public async Task<DdjjUatre?> GetUltimoPeriodoCuilAsync(double cuil)
    {
        return await db.QueryFirstOrDefaultAsync<DdjjUatre>("SELECT TOP 1 Periodo FROM DDJJUatre WHERE CUIL = @Cuil ORDER BY Periodo DESC" , new { Cuil = cuil });
    }
}
