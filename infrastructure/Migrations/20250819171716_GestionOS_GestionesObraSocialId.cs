using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GestionOS_GestionesObraSocialId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GestionObraSocialId",
                table: "GestionOsprera",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_GestionOsprera_GestionObraSocialId",
                table: "GestionOsprera",
                column: "GestionObraSocialId");

            migrationBuilder.AddForeignKey(
                name: "FK_GestionOsprera_GestionesObraSocial_GestionObraSocialId",
                table: "GestionOsprera",
                column: "GestionObraSocialId",
                principalTable: "GestionesObraSocial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GestionOsprera_GestionesObraSocial_GestionObraSocialId",
                table: "GestionOsprera");

            migrationBuilder.DropIndex(
                name: "IX_GestionOsprera_GestionObraSocialId",
                table: "GestionOsprera");

            migrationBuilder.DropColumn(
                name: "GestionObraSocialId",
                table: "GestionOsprera");
        }
    }
}
