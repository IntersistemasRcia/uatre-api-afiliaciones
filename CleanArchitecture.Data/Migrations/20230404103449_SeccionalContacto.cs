using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class SeccionalContacto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeccionalContactos_Seccionales_SeccionalId",
                table: "SeccionalContactos");

            migrationBuilder.AlterColumn<int>(
                name: "SeccionalId",
                table: "SeccionalContactos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SeccionalContactos_Seccionales_SeccionalId",
                table: "SeccionalContactos",
                column: "SeccionalId",
                principalTable: "Seccionales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeccionalContactos_Seccionales_SeccionalId",
                table: "SeccionalContactos");

            migrationBuilder.AlterColumn<int>(
                name: "SeccionalId",
                table: "SeccionalContactos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SeccionalContactos_Seccionales_SeccionalId",
                table: "SeccionalContactos",
                column: "SeccionalId",
                principalTable: "Seccionales",
                principalColumn: "Id");
        }
    }
}
