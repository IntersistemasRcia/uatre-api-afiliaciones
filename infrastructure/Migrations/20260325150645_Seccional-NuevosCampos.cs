using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeccionalNuevosCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeOnly>(
                name: "HorarioAtencion1Desde",
                table: "Seccionales",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "HorarioAtencion1Hasta",
                table: "Seccionales",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "HorarioAtencion2Desde",
                table: "Seccionales",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "HorarioAtencion2Hasta",
                table: "Seccionales",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Seccionales",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelefonoSecretarioGeneral",
                table: "Seccionales",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorarioAtencion1Desde",
                table: "Seccionales");

            migrationBuilder.DropColumn(
                name: "HorarioAtencion1Hasta",
                table: "Seccionales");

            migrationBuilder.DropColumn(
                name: "HorarioAtencion2Desde",
                table: "Seccionales");

            migrationBuilder.DropColumn(
                name: "HorarioAtencion2Hasta",
                table: "Seccionales");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Seccionales");

            migrationBuilder.DropColumn(
                name: "TelefonoSecretarioGeneral",
                table: "Seccionales");
        }
    }
}
