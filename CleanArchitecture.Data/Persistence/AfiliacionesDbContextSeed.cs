using CleanArchitecture.Domain;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public static class AfiliacionesDbContextSeed
    {
        public static async Task SeedAsync(AfiliacionesDbContext context)
        {            
            if (!context.EstadosSolicitudes!.Any())
            {
                context.EstadosSolicitudes!.AddRange(GetPreconfiguredEstadosSolicitud());
                await context.SaveChangesAsync();

                //logger.LogInformation("Se generaron los records por GetPreconfiguredEstadosSolicitud");
            }

            if (!context.Sexos!.Any())
            {
                context.Sexos!.AddRange(GetPreconfiguredSexos());
                await context.SaveChangesAsync();
            }

            if (!context.EstadosCiviles!.Any())
            {
                context.EstadosCiviles!.AddRange(GetPreconfiguredEstadosCiviles());
                await context.SaveChangesAsync();
            }

            if (!context.TiposDocumentos!.Any())
            {
                context.TiposDocumentos!.AddRange(GetPreconfiguredTiposDocumentos());
                await context.SaveChangesAsync();
            }

            if (!context.SeccionalEstados.Any())
            {
                context.SeccionalEstados!.AddRange(GetPreconfiguredSeccionalEstados());
                await context.SaveChangesAsync();
            }

            if (!context.GestionesObraSocial.Any())
            {
                context.GestionesObraSocial!.AddRange(GetPreconfiguredGestionesObraSocial());
                await context.SaveChangesAsync();
            }
        }

        private static IEnumerable<EstadoSolicitud> GetPreconfiguredEstadosSolicitud()
        {
            return new List<EstadoSolicitud>
            {
                new EstadoSolicitud { Descripcion = "Pendiente" },
                new EstadoSolicitud { Descripcion = "Activo" },
                new EstadoSolicitud { Descripcion = "No Activo" },
                new EstadoSolicitud { Descripcion = "Observado" },
                new EstadoSolicitud { Descripcion = "Rechazado" },
            };
        }

        private static IEnumerable<Sexo> GetPreconfiguredSexos()
        {
            return new List<Sexo>
            {
                new Sexo { Codigo = "MAS", Descripcion = "Masculino" },
                new Sexo { Codigo = "FEM", Descripcion = "Femenino" },
                new Sexo { Codigo = "NB", Descripcion = "No Binario" },
            };
        }

        private static IEnumerable<EstadoCivil> GetPreconfiguredEstadosCiviles()
        {
            return new List<EstadoCivil>
            {
                new EstadoCivil { Descripcion = "Soltero" },
                new EstadoCivil { Descripcion = "Casado" },
                new EstadoCivil { Descripcion = "Divorciado" },
                new EstadoCivil { Descripcion = "Separado" },
                new EstadoCivil { Descripcion = "Concubinado" },
                new EstadoCivil { Descripcion = "Otro" },

            };
        }

        private static IEnumerable<TipoDocumento> GetPreconfiguredTiposDocumentos()
        {
            return new List<TipoDocumento>
            {
                new TipoDocumento { Descripcion = "DNI" },
                new TipoDocumento { Descripcion = "LC" },
                new TipoDocumento { Descripcion = "LE" },
            };
        }

        private static IEnumerable<SeccionalEstado> GetPreconfiguredSeccionalEstados()
        {
            return new List<SeccionalEstado>
            {
                new SeccionalEstado { Descripcion = "NORMALIZADA" },
                new SeccionalEstado { Descripcion = "TRANSITORIA" },
                new SeccionalEstado { Descripcion = "EN LITIGIO" },
                new SeccionalEstado { Descripcion = "INACTIVA (NO TIENE AUTORIDADES)" },
                new SeccionalEstado { Descripcion = "BAJA" },
                new SeccionalEstado { Descripcion = "ABSORBIDA" },

            };
        }

        private static IEnumerable<GestionObraSocial> GetPreconfiguredGestionesObraSocial()
        {
            return new List<GestionObraSocial>
            {
                new GestionObraSocial { Nombre = "OSPRERA" },
                //new GestionObraSocial { Descripcion = "Activo" },
                //new GestionObraSocial { Descripcion = "No Activo" },
                //new GestionObraSocial { Descripcion = "Observado" },
                //new GestionObraSocial { Descripcion = "Rechazado" },
            };
        }
    }
}
