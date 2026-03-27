using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Infrastructure.Email;
using CleanArchitecture.Infrastructure.HealthCheck;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;

namespace CleanArchitecture.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
			var environment = services.BuildServiceProvider().GetRequiredService<IWebHostEnvironment>();
			services.AddDbContext<AfiliacionesDbContext>(opt =>
			{
				opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
				if (environment.IsDevelopment()) opt
					.LogTo(s => System.Diagnostics.Debug.WriteLine(s))
					.EnableDetailedErrors()
					.EnableSensitiveDataLogging();
			});
            
            services.AddScoped<AfiliacionesDapperContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));               

            services.Configure<EmailSettings>(e => configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailService, EmailService>();

            //Health check
            services.AddHealthChecks()
                .AddCheck("UATRE", new SqlConnectionHealthCheck(configuration.GetConnectionString("DefaultConnection")!), HealthStatus.Unhealthy, new string[] { "UATRE" });

            //Mini profiler
            services.AddMiniProfiler(options =>
            {
                options.RouteBasePath = "/profiler";
                options.ColorScheme = StackExchange.Profiling.ColorScheme.Dark;
                //options.Storage = new SqlServerStorage(configuration.GetConnectionString("MiniProfilerConnection"));
            }).AddEntityFramework();

            ////Seed
            //var contextOptions = new DbContextOptionsBuilder<AfiliacionesDbContext>()
            //    .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            //    .Options;

            //using var context = new AfiliacionesDbContext(contextOptions, services.servicpro);
            //{
            //    context.Database.Migrate();

            //    AfiliacionesDbContextSeed.SeedAsync(context).Wait();
            //}

            return services;
        }
    }
}
