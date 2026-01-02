using Microsoft.Extensions.Hosting;
using Serilog;

namespace CleanArchitecture.Infrastructure;

public static class InfrastructureHostRegistration
{
    public static IHostBuilder AddInfrastructureServices(this IHostBuilder hostBuilder)
    {
        //Serilog
        Log.Logger = new LoggerConfiguration().CreateBootstrapLogger();
        hostBuilder.UseSerilog(((ctx, lc) => lc.ReadFrom.Configuration(ctx.Configuration)));

        return hostBuilder;
    }
}
