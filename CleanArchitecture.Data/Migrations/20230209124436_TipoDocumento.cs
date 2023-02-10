using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class TipoDocumento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DNI",
                table: "Afiliados",
                newName: "Documento");

            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Afiliados",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Afiliados",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoDocumentoId",
                table: "Afiliados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TiposDocumentos",
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
                    table.PrimaryKey("PK_TiposDocumentos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Afiliados_TipoDocumentoId",
                table: "Afiliados",
                column: "TipoDocumentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Afiliados_TiposDocumentos_TipoDocumentoId",
                table: "Afiliados",
                column: "TipoDocumentoId",
                principalTable: "TiposDocumentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Afiliados_TiposDocumentos_TipoDocumentoId",
                table: "Afiliados");

            migrationBuilder.DropTable(
                name: "TiposDocumentos");

            migrationBuilder.DropIndex(
                name: "IX_Afiliados_TipoDocumentoId",
                table: "Afiliados");

            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Afiliados");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Afiliados");

            migrationBuilder.DropColumn(
                name: "TipoDocumentoId",
                table: "Afiliados");

            migrationBuilder.RenameColumn(
                name: "Documento",
                table: "Afiliados",
                newName: "DNI");
        }
    }
}
