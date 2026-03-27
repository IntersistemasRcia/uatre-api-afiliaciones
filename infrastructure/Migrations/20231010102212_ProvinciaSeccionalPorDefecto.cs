using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProvinciaSeccionalPorDefecto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeccionalIdPorDefecto",
                table: "Provincias",
                type: "int",
                nullable: false,
                defaultValue: 99999);

            migrationBuilder.CreateIndex(
                name: "IX_Provincias_SeccionalIdPorDefecto",
                table: "Provincias",
                column: "SeccionalIdPorDefecto");

            migrationBuilder.AddForeignKey(
                name: "FK_Provincias_Seccionales_SeccionalIdPorDefecto",
                table: "Provincias",
                column: "SeccionalIdPorDefecto",
                principalTable: "Seccionales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Provincias_Seccionales_SeccionalIdPorDefecto",
                table: "Provincias");

            migrationBuilder.DropIndex(
                name: "IX_Provincias_SeccionalIdPorDefecto",
                table: "Provincias");

            migrationBuilder.DropColumn(
                name: "SeccionalIdPorDefecto",
                table: "Provincias");
        }
    }
}
