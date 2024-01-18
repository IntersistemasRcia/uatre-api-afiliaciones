using CleanArchitecture.Application.Features.RefLocalidad.Command.Create;
using CleanArchitecture.Application.Features.Seccional.Queries.GetSeccionalesListSpecs;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using System.Reflection;

namespace CleanArchitecture.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Servicios
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssemblyContaining<CreateRefLocalidadCommandValidator>(includeInternalTypes: true);
            services.AddMediatR(Assembly.GetExecutingAssembly());

            ////Behaviours
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            // HttpClient Factory
            services.AddHttpClient("APIComunes", client =>
            {
                client.BaseAddress = new Uri(configuration["APIComunes"] ?? throw new ArgumentNullException(nameof(client)));
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
