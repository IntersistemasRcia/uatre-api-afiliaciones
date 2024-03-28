using CleanArchitecture.Application.Models.APIDdjj;

namespace CleanArchitecture.Application.Contracts.Persistence;

public interface IDdjjRepository
{
    Task<DdjjUatre?> GetUltimoPeriodoCuilAsync(double cuil);
}
