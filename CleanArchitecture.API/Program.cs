using CleanArchitecture.API.Middleware;
using CleanArchitecture.Application;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Configuration;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Afiliaciones", Version = "v1" });
});

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

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

app.MapControllers();

//Seed
var contextOptions = new DbContextOptionsBuilder<AfiliacionesDbContext>()
    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    .Options;

using var context = new AfiliacionesDbContext(contextOptions);
{
    context.Database.EnsureCreated();

    AfiliacionesDbContextSeed.SeedAsync(context).Wait();
}

app.Run();
