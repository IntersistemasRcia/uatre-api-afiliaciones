using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Provincia_LocalidadIdPorDefecto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Puestos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "LocalidadIdPorDefecto",
                table: "Provincias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Actividades",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_Seccionales_RefLocalidadesId",
                table: "Seccionales",
                column: "RefLocalidadesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seccionales_RefLocalidades_RefLocalidadesId",
                table: "Seccionales",
                column: "RefLocalidadesId",
                principalTable: "RefLocalidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seccionales_RefLocalidades_RefLocalidadesId",
                table: "Seccionales");

            migrationBuilder.DropIndex(
                name: "IX_Seccionales_RefLocalidadesId",
                table: "Seccionales");

            migrationBuilder.DropColumn(
                name: "LocalidadIdPorDefecto",
                table: "Provincias");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Puestos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Actividades",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
