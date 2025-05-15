using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GestionOsprera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GestionOsprera",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeccionalId = table.Column<int>(type: "int", nullable: false),
                    CUITTitular = table.Column<long>(type: "bigint", nullable: true),
                    NombreTitular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApellidoTitular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoContacto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoContacto2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailContacto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailContacto2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElPacienteEsTitular = table.Column<bool>(type: "bit", nullable: true),
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: false),
                    DniPaciente = table.Column<long>(type: "bigint", nullable: true),
                    NombrePaciente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApellidoPaciente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: true),
                    SexoId = table.Column<int>(type: "int", nullable: true),
                    MedioGestion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResultadoLlamada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionesEmailDestino = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Texto = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    FechaEnvioMail = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RespuestaEnvioEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeletedObs = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GestionOsprera", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GestionOsprera");
        }
    }
}
