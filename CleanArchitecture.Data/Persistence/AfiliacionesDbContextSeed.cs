using CleanArchitecture.Domain;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class AfiliacionesDbContextSeed
    {
        public static async Task SeedAsync(AfiliacionesDbContext context)
        {
            if (!context.EstadosSolicitud!.Any())
            {
                context.EstadosSolicitud!.AddRange(GetPreconfiguredEstadosSolicitud());
                await context.SaveChangesAsync();

                //logger.LogInformation("Se generaron los records por GetPreconfiguredEstadosSolicitud");
            }
        }

        private static IEnumerable<EstadoSolicitud> GetPreconfiguredEstadosSolicitud()
        {
            return new List<EstadoSolicitud>
            {
                new EstadoSolicitud { Descripcion = "Pendiente" },
                new EstadoSolicitud { Descripcion = "Aprobado" },
                new EstadoSolicitud { Descripcion = "Rechazado" },
            };
        }
    }
}
