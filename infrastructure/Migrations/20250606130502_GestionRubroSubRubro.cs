using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GestionRubroSubRubro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GestionRubroId",
                table: "GestionOsprera",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GestionSubRubroId",
                table: "GestionOsprera",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GestionOsprera_GestionRubroId",
                table: "GestionOsprera",
                column: "GestionRubroId");

            migrationBuilder.CreateIndex(
                name: "IX_GestionOsprera_GestionSubRubroId",
                table: "GestionOsprera",
                column: "GestionSubRubroId");

            migrationBuilder.AddForeignKey(
                name: "FK_GestionOsprera_GestionesRubro_GestionRubroId",
                table: "GestionOsprera",
                column: "GestionRubroId",
                principalTable: "GestionesRubro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GestionOsprera_GestionesSubRubro_GestionSubRubroId",
                table: "GestionOsprera",
                column: "GestionSubRubroId",
                principalTable: "GestionesSubRubro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GestionOsprera_GestionesRubro_GestionRubroId",
                table: "GestionOsprera");

            migrationBuilder.DropForeignKey(
                name: "FK_GestionOsprera_GestionesSubRubro_GestionSubRubroId",
                table: "GestionOsprera");

            migrationBuilder.DropIndex(
                name: "IX_GestionOsprera_GestionRubroId",
                table: "GestionOsprera");

            migrationBuilder.DropIndex(
                name: "IX_GestionOsprera_GestionSubRubroId",
                table: "GestionOsprera");

            migrationBuilder.DropColumn(
                name: "GestionRubroId",
                table: "GestionOsprera");

            migrationBuilder.DropColumn(
                name: "GestionSubRubroId",
                table: "GestionOsprera");
        }
    }
}
