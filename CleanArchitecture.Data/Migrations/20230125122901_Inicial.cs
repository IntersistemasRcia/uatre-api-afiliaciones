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
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Provincias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Padrones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUIL = table.Column<long>(type: "bigint", nullable: false),
                    Secuencia = table.Column<int>(type: "int", nullable: false),
                    Afiliado = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PuestoId = table.Column<int>(type: "int", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEgreso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nacionalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreAnexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CUIT = table.Column<long>(type: "bigint", nullable: false),
                    ProvinciaId = table.Column<int>(type: "int", nullable: false),
                    SeccionalId = table.Column<int>(type: "int", nullable: false),
                    SexoId = table.Column<int>(type: "int", nullable: false),
                    DNI = table.Column<long>(type: "bigint", nullable: false),
                    ActividadId = table.Column<int>(type: "int", nullable: false),
                    EstadoSolicitudId = table.Column<int>(type: "int", nullable: false),
                    AFIPCUIL = table.Column<long>(type: "bigint", nullable: true),
                    AFIPFechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AFIPNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AFIPApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AFIPRazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AFIPTipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AFIPNumeroDocumento = table.Column<int>(type: "int", nullable: true),
                    AFIPTipoPersona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AFIPTipoClave = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AFIPEstadoClave = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AFIPClaveInactivaAsociada = table.Column<long>(type: "bigint", nullable: true),
                    AFIPFechaFallecimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AFIPFormaJuridica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AFIPActividadPrincipal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AFIPIdActividadPrincipal = table.Column<int>(type: "int", nullable: true),
                    AFIPPeriodoActividadPrincipal = table.Column<int>(type: "int", nullable: true),
                    AFIPFechaContratoSocial = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AFIPMesCierre = table.Column<int>(type: "int", nullable: true),
                    AFIPDomicilioDireccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AFIPDomicilioCalle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AFIPDomicilioNumero = table.Column<int>(type: "int", nullable: true),
                    AFIPDomicilioPiso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AFIPDomicilioDepto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AFIPDomicilioSector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AFIPDomicilioTorre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AFIPDomicilioManzana = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AFIPDomicilioLocalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AFIPDomicilioProvincia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AFIPDomicilioIdProvincia = table.Column<int>(type: "int", nullable: true),
                    AFIPDomicilioCodigoPostal = table.Column<int>(type: "int", nullable: true),
                    AFIPDomicilioTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AFIPDomicilioEstado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AFIPDomicilioDatoAdicional = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AFIPDomicilioTipoDatoAdicional = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Padrones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Padrones_Actividades_ActividadId",
                        column: x => x.ActividadId,
                        principalTable: "Actividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Padrones_EstadosSolicitud_EstadoSolicitudId",
                        column: x => x.EstadoSolicitudId,
                        principalTable: "EstadosSolicitud",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Padrones_Provincias_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Padrones_Puestos_PuestoId",
                        column: x => x.PuestoId,
                        principalTable: "Puestos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Padrones_Seccionales_SeccionalId",
                        column: x => x.SeccionalId,
                        principalTable: "Seccionales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Padrones_Sexos_SexoId",
                        column: x => x.SexoId,
                        principalTable: "Sexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EstadosSolicitud",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Descripcion", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { 1, null, null, "Pendiente", null, null });

            migrationBuilder.InsertData(
                table: "EstadosSolicitud",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Descripcion", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { 2, null, null, "Aprobado", null, null });

            migrationBuilder.InsertData(
                table: "EstadosSolicitud",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Descripcion", "LastModifiedBy", "LastModifiedDate" },
                values: new object[] { 3, null, null, "Rechazado", null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Localidades_ProvinciaId",
                table: "Localidades",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Padrones_ActividadId",
                table: "Padrones",
                column: "ActividadId");

            migrationBuilder.CreateIndex(
                name: "IX_Padrones_EstadoSolicitudId",
                table: "Padrones",
                column: "EstadoSolicitudId");

            migrationBuilder.CreateIndex(
                name: "IX_Padrones_ProvinciaId",
                table: "Padrones",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Padrones_PuestoId",
                table: "Padrones",
                column: "PuestoId");

            migrationBuilder.CreateIndex(
                name: "IX_Padrones_SeccionalId",
                table: "Padrones",
                column: "SeccionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Padrones_SexoId",
                table: "Padrones",
                column: "SexoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Localidades");

            migrationBuilder.DropTable(
                name: "Padrones");

            migrationBuilder.DropTable(
                name: "Actividades");

            migrationBuilder.DropTable(
                name: "EstadosSolicitud");

            migrationBuilder.DropTable(
                name: "Provincias");

            migrationBuilder.DropTable(
                name: "Puestos");

            migrationBuilder.DropTable(
                name: "Seccionales");

            migrationBuilder.DropTable(
                name: "Sexos");
        }
    }
}
