using CleanArchitecture.API.Errors;
using CleanArchitecture.Common.Exceptions;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;

namespace CleanArchitecture.API.Middleware;

public class ExcepcionMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger<ExcepcionMiddleware> logger;
    private readonly IHostEnvironment env;

    public ExcepcionMiddleware(RequestDelegate next, ILogger<ExcepcionMiddleware> logger, IHostEnvironment env)
    {
        this.next = next;
        this.logger = logger;
        this.env = env;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {            
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);

            context.Response.ContentType = "application/json";
            var statusCode = (int)HttpStatusCode.InternalServerError;
            var result = string.Empty;

            switch (ex)
            {
                case NotFoundException notFoundException:
                    statusCode = (int)HttpStatusCode.NotFound;

                    break;

                case RequestValidationException validationException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    var validationJson = JsonConvert.SerializeObject(validationException.Errors);
                    result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, ex.Message, validationJson));

                    break;

                case BadRequestException badRequestException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    break;

                default:
                    break;
            }

            if (string.IsNullOrEmpty(result))
            {
                result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, ex.Message, ex.StackTrace));
            }

            context.Response.StatusCode = statusCode;

            await context.Response.WriteAsync(result);
        }
    }    
}
