using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.Contracts.Specification;
using CleanArchitecture.Application.Features.Afiliado.Queries;
using CleanArchitecture.Application.Models.APIComunes;
using CleanArchitecture.Common.Exceptions;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Specification;
using Dapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Text;
using System.Text.Json;

namespace CleanArchitecture.Infrastructure.Repositories;

public class AfiliadoRepository : IAfiliadoRepository
{
    private IDbConnection _db;
    private IHttpClientFactory _httpClientFactory;
    private AfiliacionesDbContext _context;
    private readonly IRefRepository _refRepository;

    public AfiliadoRepository(AfiliacionesDbContext context, IHttpClientFactory httpClientFactory, IConfiguration configuration, IRefRepository refRepository)
    {
        _httpClientFactory = httpClientFactory;
        _db = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        _context = context;
        _refRepository = refRepository;
    }
    
    public async Task<SeccionalAutoridad?> VerificarAutoridadSeccional(int id)
    {
        string SQL = $"SELECT * FROM SeccionalAutoridades WHERE AfiliadoId = {id}";
        var seccionalAutoridades = await _db.QueryAsync<SeccionalAutoridad>(SQL);
        return seccionalAutoridades?.FirstOrDefault(x => x.FechaVigenciaDesde <= DateTime.Now.Date && x.FechaVigenciaHasta >= DateTime.Now.Date);        
    }

    
    private IQueryable<Afiliado> ApplySpecification(ISpecification<Afiliado> spec)
    {
        return SpecificationEvaluator<Afiliado>.GetQuery(_context.Set<Afiliado>().AsQueryable(), spec);
    }

    public async Task CrearAfiliado(Afiliado afiliado, APIEmpresaCreate empresa)
    {
        afiliado.EmpresaId = await BuscarEmpresa(empresa);
        if (afiliado.EstadoSolicitudId == 2)
        {
            afiliado.NroAfiliado = _context.Afiliados?.OrderByDescending(x => x.NroAfiliado).FirstOrDefault()?.NroAfiliado + 1 ?? 1;
            afiliado.FechaIngreso = DateTime.Now.Date;
        }
        await _context.Set<Afiliado>().AddAsync(afiliado);
    }

    public async Task ModificarAfiliado(Afiliado afiliado, APIEmpresaCreate empresa)
    {
        if (empresa != null)
        {
            afiliado.EmpresaId = await BuscarEmpresa(empresa);
        }
        _context.Set<Afiliado>().Update(afiliado);
    }

    public void UpdateDatosAfip(Afiliado afiliado, JsonPatchDocument datosAfipModel)
    {
        datosAfipModel.ApplyTo(afiliado);
    }

    public int GetNroAfiliado()
    {
        lock (_context.Afiliados!)
        {
            return _context.Afiliados!.OrderByDescending(x => x.NroAfiliado).Take(1)!.Select(x => x.NroAfiliado).FirstOrDefault() + 1;
        }
    }

    private async Task<int> BuscarEmpresa(APIEmpresaCreate empresa)
    {
        //Creo la empresa primero
        var httpClient = _httpClientFactory.CreateClient("APIComunes");

        var json = JsonSerializer.Serialize(empresa);
        var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync("/api/Empresas", content);
        if (!response.IsSuccessStatusCode)
        {
            throw new BadRequestException("Error creando Empresa");
        }

        string? jsonString = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<int>(jsonString);
    }
}
