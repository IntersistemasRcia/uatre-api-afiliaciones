using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SolicitudAfiliacionEmpresas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SolicitudAfiliacionEmpresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SeccionalId = table.Column<int>(type: "int", nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    EstadoSolicitudId = table.Column<int>(type: "int", nullable: false),
                    EstadoFecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EstadoSolicitudObservaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoSolicitudUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
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
                    table.PrimaryKey("PK_SolicitudAfiliacionEmpresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitudAfiliacionEmpresas_EstadosSolicitudes_EstadoSolicitudId",
                        column: x => x.EstadoSolicitudId,
                        principalTable: "EstadosSolicitudes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SolicitudAfiliacionEmpresas_Seccionales_SeccionalId",
                        column: x => x.SeccionalId,
                        principalTable: "Seccionales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SolicitudAfiliacionEmpresasDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolicitudAfiliacionEmpresasId = table.Column<int>(type: "int", nullable: false),
                    Periodo = table.Column<int>(type: "int", nullable: true),
                    Total_Trabajadores = table.Column<long>(type: "bigint", nullable: true),
                    Total_Trab_Rurales = table.Column<int>(type: "int", nullable: true),
                    Total_Trab_NoRurales = table.Column<int>(type: "int", nullable: true),
                    Total_Trab_Rurales_Afiliados = table.Column<int>(type: "int", nullable: true),
                    Total_Trab_Rurales_NoAfiliados = table.Column<int>(type: "int", nullable: true),
                    Total_Trab_NoRurales_Afiliados = table.Column<int>(type: "int", nullable: true),
                    Total_Trab_NoRurales_NoAfiliados = table.Column<int>(type: "int", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
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
                    table.PrimaryKey("PK_SolicitudAfiliacionEmpresasDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitudAfiliacionEmpresasDetalle_SolicitudAfiliacionEmpresas_SolicitudAfiliacionEmpresasId",
                        column: x => x.SolicitudAfiliacionEmpresasId,
                        principalTable: "SolicitudAfiliacionEmpresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudAfiliacionEmpresas_EstadoSolicitudId",
                table: "SolicitudAfiliacionEmpresas",
                column: "EstadoSolicitudId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudAfiliacionEmpresas_SeccionalId",
                table: "SolicitudAfiliacionEmpresas",
                column: "SeccionalId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudAfiliacionEmpresasDetalle_SolicitudAfiliacionEmpresasId",
                table: "SolicitudAfiliacionEmpresasDetalle",
                column: "SolicitudAfiliacionEmpresasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SolicitudAfiliacionEmpresasDetalle");

            migrationBuilder.DropTable(
                name: "SolicitudAfiliacionEmpresas");
        }
    }
}
