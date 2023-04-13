using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class RestrictFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Afiliados_Actividades_ActividadId",
                table: "Afiliados");

            migrationBuilder.DropForeignKey(
                name: "FK_Afiliados_Empresas_EmpresaId",
                table: "Afiliados");

            migrationBuilder.DropForeignKey(
                name: "FK_Afiliados_EstadosCiviles_EstadoCivilId",
                table: "Afiliados");

            migrationBuilder.DropForeignKey(
                name: "FK_Afiliados_EstadosSolicitudes_EstadoSolicitudId",
                table: "Afiliados");

            migrationBuilder.DropForeignKey(
                name: "FK_Afiliados_Nacionalidades_NacionalidadId",
                table: "Afiliados");

            migrationBuilder.DropForeignKey(
                name: "FK_Afiliados_Puestos_PuestoId",
                table: "Afiliados");

            migrationBuilder.DropForeignKey(
                name: "FK_Afiliados_RefLocalidades_RefLocalidadId",
                table: "Afiliados");

            migrationBuilder.DropForeignKey(
                name: "FK_Afiliados_Seccionales_SeccionalId",
                table: "Afiliados");

            migrationBuilder.DropForeignKey(
                name: "FK_Afiliados_Sexos_SexoId",
                table: "Afiliados");

            migrationBuilder.DropForeignKey(
                name: "FK_Afiliados_TiposDocumentos_TipoDocumentoId",
                table: "Afiliados");

            migrationBuilder.DropForeignKey(
                name: "FK_RefLocalidades_Provincias_ProvinciaId",
                table: "RefLocalidades");

            migrationBuilder.DropForeignKey(
                name: "FK_SeccionalAutoridades_Seccionales_SeccionalId",
                table: "SeccionalAutoridades");

            migrationBuilder.DropForeignKey(
                name: "FK_SeccionalContactos_Seccionales_SeccionalId",
                table: "SeccionalContactos");

            migrationBuilder.DropForeignKey(
                name: "FK_SeccionalesLocalidades_RefLocalidades_RefLocalidadId",
                table: "SeccionalesLocalidades");

            migrationBuilder.DropForeignKey(
                name: "FK_SeccionalesLocalidades_Seccionales_SeccionalId",
                table: "SeccionalesLocalidades");

            migrationBuilder.AddForeignKey(
                name: "FK_Afiliados_Actividades_ActividadId",
                table: "Afiliados",
                column: "ActividadId",
                principalTable: "Actividades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Afiliados_Empresas_EmpresaId",
                table: "Afiliados",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Afiliados_EstadosCiviles_EstadoCivilId",
                table: "Afiliados",
                column: "EstadoCivilId",
                principalTable: "EstadosCiviles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Afiliados_EstadosSolicitudes_EstadoSolicitudId",
                table: "Afiliados",
                column: "EstadoSolicitudId",
                principalTable: "EstadosSolicitudes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Afiliados_Nacionalidades_NacionalidadId",
                table: "Afiliados",
                column: "NacionalidadId",
                principalTable: "Nacionalidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Afiliados_Puestos_PuestoId",
                table: "Afiliados",
                column: "PuestoId",
                principalTable: "Puestos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Afiliados_RefLocalidades_RefLocalidadId",
                table: "Afiliados",
                column: "RefLocalidadId",
                principalTable: "RefLocalidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Afiliados_Seccionales_SeccionalId",
                table: "Afiliados",
                column: "SeccionalId",
                principalTable: "Seccionales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Afiliados_Sexos_SexoId",
                table: "Afiliados",
                column: "SexoId",
                principalTable: "Sexos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Afiliados_TiposDocumentos_TipoDocumentoId",
                table: "Afiliados",
                column: "TipoDocumentoId",
                principalTable: "TiposDocumentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RefLocalidades_Provincias_ProvinciaId",
                table: "RefLocalidades",
                column: "ProvinciaId",
                principalTable: "Provincias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SeccionalAutoridades_Seccionales_SeccionalId",
                table: "SeccionalAutoridades",
                column: "SeccionalId",
                principalTable: "Seccionales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SeccionalContactos_Seccionales_SeccionalId",
                table: "SeccionalContactos",
                column: "SeccionalId",
                principalTable: "Seccionales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SeccionalesLocalidades_RefLocalidades_RefLocalidadId",
                table: "SeccionalesLocalidades",
                column: "RefLocalidadId",
                principalTable: "RefLocalidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SeccionalesLocalidades_Seccionales_SeccionalId",
                table: "SeccionalesLocalidades",
                column: "SeccionalId",
                principalTable: "Seccionales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Afiliados_Actividades_ActividadId",
                table: "Afiliados");

            migrationBuilder.DropForeignKey(
                name: "FK_Afiliados_Empresas_EmpresaId",
                table: "Afiliados");

            migrationBuilder.DropForeignKey(
                name: "FK_Afiliados_EstadosCiviles_EstadoCivilId",
                table: "Afiliados");

            migrationBuilder.DropForeignKey(
                name: "FK_Afiliados_EstadosSolicitudes_EstadoSolicitudId",
                table: "Afiliados");

            migrationBuilder.DropForeignKey(
                name: "FK_Afiliados_Nacionalidades_NacionalidadId",
                table: "Afiliados");

            migrationBuilder.DropForeignKey(
                name: "FK_Afiliados_Puestos_PuestoId",
                table: "Afiliados");

            migrationBuilder.DropForeignKey(
                name: "FK_Afiliados_RefLocalidades_RefLocalidadId",
                table: "Afiliados");

            migrationBuilder.DropForeignKey(
                name: "FK_Afiliados_Seccionales_SeccionalId",
                table: "Afiliados");

            migrationBuilder.DropForeignKey(
                name: "FK_Afiliados_Sexos_SexoId",
                table: "Afiliados");

            migrationBuilder.DropForeignKey(
                name: "FK_Afiliados_TiposDocumentos_TipoDocumentoId",
                table: "Afiliados");

            migrationBuilder.DropForeignKey(
                name: "FK_RefLocalidades_Provincias_ProvinciaId",
                table: "RefLocalidades");

            migrationBuilder.DropForeignKey(
                name: "FK_SeccionalAutoridades_Seccionales_SeccionalId",
                table: "SeccionalAutoridades");

            migrationBuilder.DropForeignKey(
                name: "FK_SeccionalContactos_Seccionales_SeccionalId",
                table: "SeccionalContactos");

            migrationBuilder.DropForeignKey(
                name: "FK_SeccionalesLocalidades_RefLocalidades_RefLocalidadId",
                table: "SeccionalesLocalidades");

            migrationBuilder.DropForeignKey(
                name: "FK_SeccionalesLocalidades_Seccionales_SeccionalId",
                table: "SeccionalesLocalidades");

            migrationBuilder.AddForeignKey(
                name: "FK_Afiliados_Actividades_ActividadId",
                table: "Afiliados",
                column: "ActividadId",
                principalTable: "Actividades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Afiliados_Empresas_EmpresaId",
                table: "Afiliados",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Afiliados_EstadosCiviles_EstadoCivilId",
                table: "Afiliados",
                column: "EstadoCivilId",
                principalTable: "EstadosCiviles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Afiliados_EstadosSolicitudes_EstadoSolicitudId",
                table: "Afiliados",
                column: "EstadoSolicitudId",
                principalTable: "EstadosSolicitudes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Afiliados_Nacionalidades_NacionalidadId",
                table: "Afiliados",
                column: "NacionalidadId",
                principalTable: "Nacionalidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Afiliados_Puestos_PuestoId",
                table: "Afiliados",
                column: "PuestoId",
                principalTable: "Puestos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Afiliados_RefLocalidades_RefLocalidadId",
                table: "Afiliados",
                column: "RefLocalidadId",
                principalTable: "RefLocalidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Afiliados_Seccionales_SeccionalId",
                table: "Afiliados",
                column: "SeccionalId",
                principalTable: "Seccionales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Afiliados_Sexos_SexoId",
                table: "Afiliados",
                column: "SexoId",
                principalTable: "Sexos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Afiliados_TiposDocumentos_TipoDocumentoId",
                table: "Afiliados",
                column: "TipoDocumentoId",
                principalTable: "TiposDocumentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RefLocalidades_Provincias_ProvinciaId",
                table: "RefLocalidades",
                column: "ProvinciaId",
                principalTable: "Provincias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeccionalAutoridades_Seccionales_SeccionalId",
                table: "SeccionalAutoridades",
                column: "SeccionalId",
                principalTable: "Seccionales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeccionalContactos_Seccionales_SeccionalId",
                table: "SeccionalContactos",
                column: "SeccionalId",
                principalTable: "Seccionales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeccionalesLocalidades_RefLocalidades_RefLocalidadId",
                table: "SeccionalesLocalidades",
                column: "RefLocalidadId",
                principalTable: "RefLocalidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeccionalesLocalidades_Seccionales_SeccionalId",
                table: "SeccionalesLocalidades",
                column: "SeccionalId",
                principalTable: "Seccionales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
