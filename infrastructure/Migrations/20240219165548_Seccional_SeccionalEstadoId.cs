using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seccional_SeccionalEstadoId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeccionalEstadoId",
                table: "Seccionales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Seccionales_SeccionalEstadoId",
                table: "Seccionales",
                column: "SeccionalEstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seccionales_SeccionalEstados_SeccionalEstadoId",
                table: "Seccionales",
                column: "SeccionalEstadoId",
                principalTable: "SeccionalEstados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seccionales_SeccionalEstados_SeccionalEstadoId",
                table: "Seccionales");

            migrationBuilder.DropIndex(
                name: "IX_Seccionales_SeccionalEstadoId",
                table: "Seccionales");

            migrationBuilder.DropColumn(
                name: "SeccionalEstadoId",
                table: "Seccionales");
        }
    }
}
