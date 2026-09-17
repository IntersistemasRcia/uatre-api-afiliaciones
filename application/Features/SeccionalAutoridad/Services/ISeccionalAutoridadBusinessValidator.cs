using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.SeccionalAutoridad.Services
{
    public interface ISeccionalAutoridadBusinessValidator
    {
        Task ValidateAsync(CleanArchitecture.Domain.SeccionalAutoridad entidad, int? excludeId = null, bool isReactivation = false);
    }
}