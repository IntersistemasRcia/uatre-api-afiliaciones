using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GUIDChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "TiposDocumentos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.Sql(
                @"Update TiposDocumentos 
                  SET Guid = NEWID()"
            );

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Sexos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.Sql(
                @"Update Sexos 
                  SET Guid = NEWID()"
            );

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "SeccionalEstados",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.Sql(
                @"Update Sexos 
                  SET Guid = NEWID()"
            );

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "SeccionalesLocalidades",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.Sql(
                @"Update Sexos 
                  SET Guid = NEWID()"
            );

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Seccionales",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.Sql(
                @"Update Sexos 
                  SET Guid = NEWID()"
            );

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "SeccionalContactos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.Sql(
                @"Update SeccionalContactos 
                  SET Guid = NEWID()"
            );

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "SeccionalAutoridades",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.Sql(
                @"Update SeccionalAutoridades 
                  SET Guid = NEWID()"
            );

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "RefLocalidades",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.Sql(
                @"Update RefLocalidades 
                  SET Guid = NEWID()"
            );

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Puestos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.Sql(
                @"Update Puestos 
                  SET Guid = NEWID()"
            );

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Provincias",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.Sql(
                @"Update Provincias 
                  SET Guid = NEWID()"
            );

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Nacionalidades",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.Sql(
                @"Update Nacionalidades 
                  SET Guid = NEWID()"
            );

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "EstadosSolicitudes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.Sql(
                @"Update EstadosSolicitudes 
                  SET Guid = NEWID()"
            );

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "EstadosCiviles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.Sql(
                @"Update EstadosCiviles 
                  SET Guid = NEWID()"
            );

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Afiliados",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.Sql(
                @"Update Afiliados 
                  SET Guid = NEWID()"
            );

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "AfiliadoEstadosSolicitud",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.Sql(
                @"Update AfiliadoEstadosSolicitud 
                  SET Guid = NEWID()"
            );

            migrationBuilder.AddColumn<Guid>(
                name: "Guid",
                table: "Actividades",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.Sql(
                @"Update Actividades 
                  SET Guid = NEWID()"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Guid",
                table: "TiposDocumentos");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Sexos");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "SeccionalEstados");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "SeccionalesLocalidades");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Seccionales");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "SeccionalContactos");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "SeccionalAutoridades");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "RefLocalidades");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Puestos");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Provincias");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Nacionalidades");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "EstadosSolicitudes");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "EstadosCiviles");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Afiliados");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "AfiliadoEstadosSolicitud");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Actividades");
        }
    }
}
