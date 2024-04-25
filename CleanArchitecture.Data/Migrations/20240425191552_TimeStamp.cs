using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TimeStamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "TiposDocumentos",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Sexos",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SeccionalEstados",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SeccionalesLocalidades",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Seccionales",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SeccionalContactos",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SeccionalAutoridades",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "RefLocalidades",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Puestos",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Provincias",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "NotificacionesDetalle",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Notificaciones",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Nacionalidades",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InformesSapDetalles",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "InformesSap",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "EstadosSolicitudes",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "EstadosCiviles",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AfiliadosFormularioAfiliacion",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Afiliados",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "AfiliadoEstadosSolicitud",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Actividades",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "TiposDocumentos");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Sexos");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SeccionalEstados");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SeccionalesLocalidades");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Seccionales");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SeccionalContactos");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SeccionalAutoridades");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "RefLocalidades");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Puestos");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Provincias");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "NotificacionesDetalle");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Notificaciones");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Nacionalidades");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InformesSapDetalles");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "InformesSap");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "EstadosSolicitudes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "EstadosCiviles");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AfiliadosFormularioAfiliacion");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Afiliados");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "AfiliadoEstadosSolicitud");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Actividades");
        }
    }
}
