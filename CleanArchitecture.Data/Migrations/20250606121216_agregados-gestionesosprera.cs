using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class agregadosgestionesosprera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AtencionesPrevias",
                table: "GestionOsprera",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConCoberturaOsprera",
                table: "GestionOsprera",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GestionAreaOspreraId",
                table: "GestionOsprera",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GestionEstadoId",
                table: "GestionOsprera",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GestionSituacionId",
                table: "GestionOsprera",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TipoPrestador",
                table: "GestionOsprera",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GestionesAreaOsprera",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_GestionesAreaOsprera", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GestionesEstado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_GestionesEstado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GestionesRubro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_GestionesRubro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GestionesSituacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GestionEstadoId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_GestionesSituacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GestionesSituacion_GestionesEstado_GestionEstadoId",
                        column: x => x.GestionEstadoId,
                        principalTable: "GestionesEstado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GestionesSubRubro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GestionRubroId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_GestionesSubRubro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GestionesSubRubro_GestionesRubro_GestionRubroId",
                        column: x => x.GestionRubroId,
                        principalTable: "GestionesRubro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GestionOsprera_GestionAreaOspreraId",
                table: "GestionOsprera",
                column: "GestionAreaOspreraId");

            migrationBuilder.CreateIndex(
                name: "IX_GestionOsprera_GestionEstadoId",
                table: "GestionOsprera",
                column: "GestionEstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_GestionOsprera_GestionSituacionId",
                table: "GestionOsprera",
                column: "GestionSituacionId");

            migrationBuilder.CreateIndex(
                name: "IX_GestionesSituacion_GestionEstadoId",
                table: "GestionesSituacion",
                column: "GestionEstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_GestionesSubRubro_GestionRubroId",
                table: "GestionesSubRubro",
                column: "GestionRubroId");

            migrationBuilder.AddForeignKey(
                name: "FK_GestionOsprera_GestionesAreaOsprera_GestionAreaOspreraId",
                table: "GestionOsprera",
                column: "GestionAreaOspreraId",
                principalTable: "GestionesAreaOsprera",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GestionOsprera_GestionesEstado_GestionEstadoId",
                table: "GestionOsprera",
                column: "GestionEstadoId",
                principalTable: "GestionesEstado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GestionOsprera_GestionesSituacion_GestionSituacionId",
                table: "GestionOsprera",
                column: "GestionSituacionId",
                principalTable: "GestionesSituacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GestionOsprera_GestionesAreaOsprera_GestionAreaOspreraId",
                table: "GestionOsprera");

            migrationBuilder.DropForeignKey(
                name: "FK_GestionOsprera_GestionesEstado_GestionEstadoId",
                table: "GestionOsprera");

            migrationBuilder.DropForeignKey(
                name: "FK_GestionOsprera_GestionesSituacion_GestionSituacionId",
                table: "GestionOsprera");

            migrationBuilder.DropTable(
                name: "GestionesAreaOsprera");

            migrationBuilder.DropTable(
                name: "GestionesSituacion");

            migrationBuilder.DropTable(
                name: "GestionesSubRubro");

            migrationBuilder.DropTable(
                name: "GestionesEstado");

            migrationBuilder.DropTable(
                name: "GestionesRubro");

            migrationBuilder.DropIndex(
                name: "IX_GestionOsprera_GestionAreaOspreraId",
                table: "GestionOsprera");

            migrationBuilder.DropIndex(
                name: "IX_GestionOsprera_GestionEstadoId",
                table: "GestionOsprera");

            migrationBuilder.DropIndex(
                name: "IX_GestionOsprera_GestionSituacionId",
                table: "GestionOsprera");

            migrationBuilder.DropColumn(
                name: "AtencionesPrevias",
                table: "GestionOsprera");

            migrationBuilder.DropColumn(
                name: "ConCoberturaOsprera",
                table: "GestionOsprera");

            migrationBuilder.DropColumn(
                name: "GestionAreaOspreraId",
                table: "GestionOsprera");

            migrationBuilder.DropColumn(
                name: "GestionEstadoId",
                table: "GestionOsprera");

            migrationBuilder.DropColumn(
                name: "GestionSituacionId",
                table: "GestionOsprera");

            migrationBuilder.DropColumn(
                name: "TipoPrestador",
                table: "GestionOsprera");
        }
    }
}
