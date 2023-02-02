using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actividades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadosSolicitud",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosSolicitud", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nacionalidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nacionalidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provincias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Puestos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puestos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seccionales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seccionales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sexos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProvinciaId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Localidades_Provincias_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Afiliados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUIL = table.Column<long>(type: "bigint", nullable: false),
                    Secuencia = table.Column<int>(type: "int", nullable: false),
                    NroAfiliado = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PuestoId = table.Column<int>(type: "int", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEgreso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NacionalidadId = table.Column<int>(type: "int", nullable: false),
                    NombreAnexo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CUIT = table.Column<long>(type: "bigint", nullable: false),
                    SeccionalId = table.Column<int>(type: "int", nullable: false),
                    SexoId = table.Column<int>(type: "int", nullable: false),
                    DNI = table.Column<long>(type: "bigint", nullable: false),
                    ActividadId = table.Column<int>(type: "int", nullable: false),
                    EstadoSolicitudId = table.Column<int>(type: "int", nullable: false),
                    AFIPCUIL = table.Column<long>(type: "bigint", nullable: true),
                    AFIPFechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AFIPNombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AFIPApellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AFIPRazonSocial = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AFIPTipoDocumento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AFIPNumeroDocumento = table.Column<int>(type: "int", nullable: true),
                    AFIPTipoPersona = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AFIPTipoClave = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AFIPEstadoClave = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AFIPClaveInactivaAsociada = table.Column<long>(type: "bigint", nullable: true),
                    AFIPFechaFallecimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AFIPFormaJuridica = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AFIPActividadPrincipal = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AFIPIdActividadPrincipal = table.Column<int>(type: "int", nullable: true),
                    AFIPPeriodoActividadPrincipal = table.Column<int>(type: "int", nullable: true),
                    AFIPFechaContratoSocial = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AFIPMesCierre = table.Column<int>(type: "int", nullable: true),
                    AFIPDomicilioDireccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AFIPDomicilioCalle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AFIPDomicilioNumero = table.Column<int>(type: "int", nullable: true),
                    AFIPDomicilioPiso = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AFIPDomicilioDepto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AFIPDomicilioSector = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AFIPDomicilioTorre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AFIPDomicilioManzana = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AFIPDomicilioLocalidad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AFIPDomicilioProvincia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AFIPDomicilioIdProvincia = table.Column<int>(type: "int", nullable: true),
                    AFIPDomicilioCodigoPostal = table.Column<int>(type: "int", nullable: true),
                    AFIPDomicilioTipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AFIPDomicilioEstado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AFIPDomicilioDatoAdicional = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AFIPDomicilioTipoDatoAdicional = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afiliados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Afiliados_Actividades_ActividadId",
                        column: x => x.ActividadId,
                        principalTable: "Actividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Afiliados_EstadosSolicitud_EstadoSolicitudId",
                        column: x => x.EstadoSolicitudId,
                        principalTable: "EstadosSolicitud",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Afiliados_Nacionalidades_NacionalidadId",
                        column: x => x.NacionalidadId,
                        principalTable: "Nacionalidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Afiliados_Puestos_PuestoId",
                        column: x => x.PuestoId,
                        principalTable: "Puestos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Afiliados_Seccionales_SeccionalId",
                        column: x => x.SeccionalId,
                        principalTable: "Seccionales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Afiliados_Sexos_SexoId",
                        column: x => x.SexoId,
                        principalTable: "Sexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeccionalesLocalidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalidadId = table.Column<int>(type: "int", nullable: false),
                    SeccionalId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeccionalesLocalidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeccionalesLocalidades_Localidades_LocalidadId",
                        column: x => x.LocalidadId,
                        principalTable: "Localidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeccionalesLocalidades_Seccionales_SeccionalId",
                        column: x => x.SeccionalId,
                        principalTable: "Seccionales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Afiliados_ActividadId",
                table: "Afiliados",
                column: "ActividadId");

            migrationBuilder.CreateIndex(
                name: "IX_Afiliados_EstadoSolicitudId",
                table: "Afiliados",
                column: "EstadoSolicitudId");

            migrationBuilder.CreateIndex(
                name: "IX_Afiliados_NacionalidadId",
                table: "Afiliados",
                column: "NacionalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Afiliados_PuestoId",
                table: "Afiliados",
                column: "PuestoId");

            migrationBuilder.CreateIndex(
                name: "IX_Afiliados_SeccionalId",
                table: "Afiliados",
                column: "SeccionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Afiliados_SexoId",
                table: "Afiliados",
                column: "SexoId");

            migrationBuilder.CreateIndex(
                name: "IX_Localidades_ProvinciaId",
                table: "Localidades",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_SeccionalesLocalidades_LocalidadId",
                table: "SeccionalesLocalidades",
                column: "LocalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_SeccionalesLocalidades_SeccionalId",
                table: "SeccionalesLocalidades",
                column: "SeccionalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Afiliados");

            migrationBuilder.DropTable(
                name: "SeccionalesLocalidades");

            migrationBuilder.DropTable(
                name: "Actividades");

            migrationBuilder.DropTable(
                name: "EstadosSolicitud");

            migrationBuilder.DropTable(
                name: "Nacionalidades");

            migrationBuilder.DropTable(
                name: "Puestos");

            migrationBuilder.DropTable(
                name: "Sexos");

            migrationBuilder.DropTable(
                name: "Localidades");

            migrationBuilder.DropTable(
                name: "Seccionales");

            migrationBuilder.DropTable(
                name: "Provincias");
        }
    }
}
