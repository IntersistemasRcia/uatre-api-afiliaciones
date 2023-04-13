using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Infrastructure.Email;
using CleanArchitecture.Infrastructure.HealthCheck;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using StackExchange.Profiling.Storage;

namespace CleanArchitecture.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AfiliacionesDbContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<ISeccionalAutoridadRepository, SeccionalAutoridadRepository>();
            //services.AddScoped<IStreamerRepository, StreamerRepository>();

            services.Configure<EmailSettings>(e => configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();

            //Health check
            services.AddHealthChecks()
                .AddCheck("UATRE", new SqlConnectionHealthCheck(configuration.GetConnectionString("DefaultConnection")!), HealthStatus.Unhealthy, new string[] { "UATRE" });

            //Mini profiler
            services.AddMiniProfiler(options =>
            {
                options.RouteBasePath = "/apiafiliacionesprofiler";
                options.ColorScheme = StackExchange.Profiling.ColorScheme.Dark;
                options.Storage = new SqlServerStorage(configuration.GetConnectionString("MiniProfilerConnection"));
            }).AddEntityFramework();

            return services;
        }
    }
}
