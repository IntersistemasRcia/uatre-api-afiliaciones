using CleanArchitecture.API.Middleware;
using CleanArchitecture.Application;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Afiliaciones", Version = "v1" });
});

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddInfrastructureServices(builder.Configuration);


builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        //builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
    

});

//Serilog
Log.Logger = new LoggerConfiguration().CreateBootstrapLogger();
builder.Host.UseSerilog(((ctx, lc) => lc.ReadFrom.Configuration(ctx.Configuration)));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExcepcionMiddleware>();

//app.UseAuthentication();
app.UseAuthorization();

app.UseRouting();
app.UseCors("CorsPolicy");
app.UseMiniProfiler();
app.MapHealthChecks("/hc");
app.UseSerilogRequestLogging();

app.MapControllers();

// Ensure DB created
using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
using var context = serviceScope.ServiceProvider.GetService<AfiliacionesDbContext>();
{
    context!.Database.Migrate();

    AfiliacionesDbContextSeed.SeedAsync(context).Wait();
}

app.Run();
