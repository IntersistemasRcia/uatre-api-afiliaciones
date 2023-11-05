using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Commom;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Text;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class AfiliacionesDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AfiliacionesDbContext(DbContextOptions<AfiliacionesDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //var token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            var userId = _httpContextAccessor.HttpContext.Items["User"]?.ToString() ?? "SinDatos";

            foreach (var entry in ChangeTracker.Entries<EntidadAuditable>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = userId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = userId;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.DeletedDate = DateTime.Now;
                        entry.Entity.DeletedBy = userId;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //excluidas de migrations
            //modelBuilder.Entity<DDJJUatre>().ToTable(nameof(DDJJUatre), t => t.ExcludeFromMigrations());


            //No dejar borrar registros padres con hijos
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        private string? ValidateToken(string token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("KJ823762381kjhsKJAKJ78782");
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = jwtToken.Claims.First(x => x.Type == "email").Value;

                // return user id from JWT token if validation successful
                return userId;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }

        public DbSet<Afiliado>? Afiliados { get; set; }
        public DbSet<Actividad>? Actividades { get; set; }
        public DbSet<Provincia>? Provincias { get; set; }
        public DbSet<Puesto>? Puestos { get; set; }
        public DbSet<Seccional>? Seccionales { get; set; }
        public DbSet<Sexo>? Sexos { get; set; }
        public DbSet<EstadoSolicitud>? EstadosSolicitudes { get; set; }
        public DbSet<Nacionalidad>? Nacionalidades { get; set; }
        public DbSet<SeccionalLocalidad>? SeccionalesLocalidades { get; set; }
        public DbSet<EstadoCivil>? EstadosCiviles { get; set; }        
        public DbSet<TipoDocumento>? TiposDocumentos { get; set; }
        public DbSet<RefLocalidad>? RefLocalidades { get; set; }
        public DbSet<SeccionalContacto>? SeccionalContactos { get; set; }
        public DbSet<SeccionalAutoridad>? SeccionalAutoridades { get; set; }
        public DbSet<AfiliadoEstadoSolicitud> AfiliadoEstadosSolicitud { get; set; }
    }
}
