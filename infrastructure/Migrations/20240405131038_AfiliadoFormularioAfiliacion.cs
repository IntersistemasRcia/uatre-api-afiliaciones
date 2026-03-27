using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AfiliadoFormularioAfiliacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AfiliadosFormularioAfiliacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CUIL = table.Column<long>(type: "bigint", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Domicilio = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SexoId = table.Column<int>(type: "int", nullable: false),
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: false),
                    Documento = table.Column<long>(type: "bigint", nullable: false),
                    EstadoCivilId = table.Column<int>(type: "int", nullable: false),
                    EstadoCivil = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SeccionalId = table.Column<int>(type: "int", nullable: false),
                    Seccional = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OficioId = table.Column<int>(type: "int", nullable: false),
                    Oficio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ActividadIdAfiliado = table.Column<int>(type: "int", nullable: false),
                    ActividadAfiliado = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NacionalidadId = table.Column<int>(type: "int", nullable: false),
                    Nacionalidad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RefLocalidadIdAfiliado = table.Column<int>(type: "int", nullable: false),
                    NombreLocalidadAfiliado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProvinciaId = table.Column<int>(type: "int", nullable: false),
                    CUITEmpresa = table.Column<long>(type: "bigint", nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DomicilioEmpresa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RefLocalidadIdEmpresa = table.Column<int>(type: "int", nullable: false),
                    NombreLocalidadEmpresa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ProvinciaidEmpresa = table.Column<int>(type: "int", nullable: false),
                    ActividadIdEmpresa = table.Column<int>(type: "int", nullable: false),
                    ActividadEmpresa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TelefonoEmpresa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CelularEmpresa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmailEmpresa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaIncorporacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AfiliadoIdAsignado = table.Column<int>(type: "int", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeletedObs = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AfiliadosFormularioAfiliacion", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AfiliadosFormularioAfiliacion");
        }
    }
}
