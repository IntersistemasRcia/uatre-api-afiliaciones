using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SolicitudAfiEmpresaAddColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Periodo",
                table: "SolicitudAfiliacionEmpresas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Total_Trab_NoRurales",
                table: "SolicitudAfiliacionEmpresas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Total_Trab_NoRurales_Afiliados",
                table: "SolicitudAfiliacionEmpresas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Total_Trab_NoRurales_NoAfiliados",
                table: "SolicitudAfiliacionEmpresas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Total_Trab_Rurales",
                table: "SolicitudAfiliacionEmpresas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Total_Trab_Rurales_Afiliados",
                table: "SolicitudAfiliacionEmpresas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Total_Trab_Rurales_NoAfiliados",
                table: "SolicitudAfiliacionEmpresas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Total_Trabajadores",
                table: "SolicitudAfiliacionEmpresas",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Periodo",
                table: "SolicitudAfiliacionEmpresas");

            migrationBuilder.DropColumn(
                name: "Total_Trab_NoRurales",
                table: "SolicitudAfiliacionEmpresas");

            migrationBuilder.DropColumn(
                name: "Total_Trab_NoRurales_Afiliados",
                table: "SolicitudAfiliacionEmpresas");

            migrationBuilder.DropColumn(
                name: "Total_Trab_NoRurales_NoAfiliados",
                table: "SolicitudAfiliacionEmpresas");

            migrationBuilder.DropColumn(
                name: "Total_Trab_Rurales",
                table: "SolicitudAfiliacionEmpresas");

            migrationBuilder.DropColumn(
                name: "Total_Trab_Rurales_Afiliados",
                table: "SolicitudAfiliacionEmpresas");

            migrationBuilder.DropColumn(
                name: "Total_Trab_Rurales_NoAfiliados",
                table: "SolicitudAfiliacionEmpresas");

            migrationBuilder.DropColumn(
                name: "Total_Trabajadores",
                table: "SolicitudAfiliacionEmpresas");
        }
    }
}
