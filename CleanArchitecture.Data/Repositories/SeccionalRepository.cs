using Azure.Core;
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
    public class SeccionalRepository : ISeccionalRepository
    {
        private AfiliacionesDbContext _context;

        public SeccionalRepository(AfiliacionesDbContext context)
        {
            _context = context;
        }

        public async Task CrearSeccional(Seccional seccional)
        {
            try
            {
                await _context.Set<Seccional>().AddAsync(seccional);                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
