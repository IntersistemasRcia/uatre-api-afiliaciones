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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Polly;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using static Dapper.SqlMapper;

namespace CleanArchitecture.Infrastructure.Repositories
{
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

        public async Task ResolverSolicitudAsync(Afiliado afiliado, JsonPatchDocument model)
        {
            int estadoSolicitudAnt = afiliado.EstadoSolicitudId;
            int.TryParse(model.Operations[0].value.ToString(), out int EstadoSolicitud);
            switch (EstadoSolicitud) //Estado enviado
            {                
                case 2: //Activo
                    var nroAfiliado = afiliado.NroAfiliado;

                    //Solo busco el siguiente nro afiliado si el afiliado estaba pendiente
                    if (afiliado.EstadoSolicitudId == 1)
                    {
                        lock (_context.Afiliados!)
                        {
                            nroAfiliado = _context.Afiliados!.OrderByDescending(x => x.NroAfiliado).Take(1)!.Select(x => x.NroAfiliado).FirstOrDefault() + 1;
                        }   
                    }
                        
                    model.Operations[1].value = DateTime.Now.Date; //Convert.ToDateTime(model.Operations[1].value).Date;
                    model.Operations[2].value = nroAfiliado;
                    model.Operations[4].value = null;
                    
                    
                    break;

                case 3: //No activo
                    model.Operations[1].value = afiliado.FechaIngreso;
                    model.Operations[2].value = afiliado.NroAfiliado;
                    model.Operations[4].value = Convert.ToDateTime(model.Operations[4].value).Date;

                    break;                

                default:
                    break;
            }

            model.ApplyTo(afiliado);

            if (estadoSolicitudAnt != EstadoSolicitud)
            {
                //Auditoria con estado Anterior
                AfiliadoEstadoSolicitud afiliadoEstadoSolicitud = new AfiliadoEstadoSolicitud(afiliado.Id, estadoSolicitudAnt);
                await _context.Set<AfiliadoEstadoSolicitud>().AddAsync(afiliadoEstadoSolicitud);
            }            
        }

        public async Task<IReadOnlyCollection<Afiliado>> VerificarAutoridadSeccional(IReadOnlyCollection<Afiliado> afiliados)
        {
            foreach (var item in afiliados)
            {
                string SQL = $"SELECT * FROM SeccionalAutoridades WHERE AfiliadoId = {item.Id}";
                var seccionalAutoridades = await _db.QueryAsync<SeccionalAutoridad>(SQL);
                var seccionalAutoridad = seccionalAutoridades?.FirstOrDefault(x => x.FechaVigenciaDesde <= DateTime.Now.Date && x.FechaVigenciaHasta >= DateTime.Now.Date);
                item.SeccionalAutoridadId = seccionalAutoridad != null ? seccionalAutoridad.Id : 0;
            }
            return afiliados;
        }

        public async Task<Afiliado> BuscarAfiliadoPorSpecs(ISpecification<Afiliado> spec)
        {
            Afiliado? afiliado = await ApplySpecification(spec).FirstOrDefaultAsync();

            if (afiliado == null)
            {
                throw new NotFoundException(typeof(Afiliado).Name, "No se encontró Afiliado con el Specification indicado");
            }

            //var httpClient = _httpClientFactory.CreateClient("APIComunes");
            //var response = await httpClient.GetAsync($"/api/Empresas/GetById?Id={afiliado.EmpresaId}");
            //string? jsonString = await response.Content.ReadAsStringAsync();
            //var empresa = JsonSerializer.Deserialize<APIEmpresaResponse>(jsonString);

            var empresa = await _refRepository.GetEmpresaById(afiliado.EmpresaId);
            var refDelegacion = await _refRepository.GetDelegacionById(afiliado.Seccional!.RefDelegacionId);

            afiliado.EmpresaDescripcion = empresa?.RazonSocial ?? "";
            afiliado.EmpresaCUIT = empresa?.CUIT ?? 0;
            afiliado.Seccional!.RefDelegacionDescripcion = refDelegacion?.Nombre ?? "";

            return afiliado;
        }

        public async Task<IReadOnlyCollection<Afiliado>> ListarAfiliados(ISpecification<Afiliado> spec, bool disableTracking = true)
        {
            IReadOnlyCollection<Afiliado> list;
            if (disableTracking)
                list = await ApplySpecification(spec).AsNoTracking().ToListAsync();
            else
                list = await ApplySpecification(spec).ToListAsync();

            if (list.Any())
            {
                //Empresa
                //var idsEmpresa = list.GroupBy(x => x.EmpresaId).Select(x => x.Key).ToList();
                //var httpClient = _httpClientFactory.CreateClient("APIComunes");
                //var empresas = new List<APIEmpresaResponse>();
                ////httpClient.DefaultRequestHeaders.Add("ApiKey", "dad03323-09ae-41f2-8d2f-15f4ddfcecb7");

                //StringBuilder builder = new StringBuilder();
                //foreach (var id in idsEmpresa)
                //{
                //    builder.Append(builder.Length == 0 ? $"Id={id}" : $"&Id={id}");
                //}

                //var response = await httpClient.GetAsync($"/api/Empresas/GetByIds?{builder}");
                //if (response.IsSuccessStatusCode)
                //{
                //    string? jsonString = await response.Content.ReadAsStringAsync();
                //    var apiEmpresas = JsonSerializer.Deserialize<IEnumerable<APIEmpresaResponse>>(jsonString);
                //    empresas.AddRange(apiEmpresas);
                //}

                ////RefDelegacion
                //var httpClientRefDelegacion = _httpClientFactory.CreateClient("APIComunes");
                //var refDelegaciones = new List<APIRefDelegacionResponse>();
                ////httpClient.DefaultRequestHeaders.Add("ApiKey", "dad03323-09ae-41f2-8d2f-15f4ddfcecb7");                

                //IReadOnlyCollection<APIRefDelegacionResponse>? apiRefDelegaciones = null;
                //var refDelegacionesResponse = await httpClientRefDelegacion.GetAsync($"/api/RefDelegacion/GetAll");
                //if (refDelegacionesResponse.IsSuccessStatusCode)
                //{
                //    string? jsonString = await refDelegacionesResponse.Content.ReadAsStringAsync();
                //    apiRefDelegaciones = JsonSerializer.Deserialize<IReadOnlyCollection<APIRefDelegacionResponse>>(jsonString);
                //}

                foreach (var afiliado in list)
                {
                    var empresa = await _refRepository.GetEmpresaById(afiliado.EmpresaId);
                    var refDelegacion = await _refRepository.GetDelegacionById(afiliado.Seccional!.RefDelegacionId);

                    afiliado.EmpresaDescripcion = empresa?.RazonSocial ?? "";
                    afiliado.EmpresaCUIT = empresa?.CUIT ?? 0;
                    afiliado.Seccional!.RefDelegacionDescripcion = refDelegacion?.Nombre ?? "";
                }
            }            

            return list;
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
}
