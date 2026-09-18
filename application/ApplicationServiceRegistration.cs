using CleanArchitecture.Application.Features.RefLocalidad.Command.Create;
using CleanArchitecture.Application.Mappings;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using System.Reflection;
using CleanArchitecture.Application.Features.SeccionalAutoridad.Services;

namespace CleanArchitecture.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Servicios
            services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());
            services.AddValidatorsFromAssemblyContaining<CreateRefLocalidadCommandValidator>(includeInternalTypes: true);
            services.AddMediatR(r => r.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // Registrar el validador de negocio para SeccionalAutoridad
            services.AddScoped<ISeccionalAutoridadBusinessValidator, SeccionalAutoridadBusinessValidator>();

            // HttpClient Factory
            services.AddHttpClient("APIComunes", client =>
            {
                client.BaseAddress = new Uri(configuration["APIComunes"] ?? throw new ArgumentNullException(nameof(client)));
            })
                .SetHandlerLifetime(TimeSpan.FromMinutes(5))
                .AddPolicyHandler(GetRetryPolicy());

            services.AddHttpClient("APIAuditoria", client =>
            {
                client.BaseAddress = new Uri(configuration["APIAuditoria"] ?? throw new ArgumentNullException(nameof(client)));
            })
                .SetHandlerLifetime(TimeSpan.FromMinutes(5))
                .AddPolicyHandler(GetRetryPolicy());
            //.AddPolicyHandler(GetCircuitBreakerPolicy());

            //Cors

            return services;
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                (exception, timeSpan, context) =>
                {
                    Console.WriteLine("retry" + exception);
                }
                );
        }

        static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(2, TimeSpan.FromSeconds(10));
        }
    }
}
