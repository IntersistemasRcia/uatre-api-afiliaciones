using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actividades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_Actividades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DDJJUatre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUIT = table.Column<double>(type: "float", nullable: false),
                    CUIL = table.Column<double>(type: "float", nullable: false),
                    Periodo = table.Column<int>(type: "int", nullable: false),
                    ObligacionNro = table.Column<double>(type: "float", nullable: false),
                    ObligacionSecuencia = table.Column<int>(type: "int", nullable: false),
                    Banco = table.Column<int>(type: "int", nullable: false),
                    Rectificativa = table.Column<int>(type: "int", nullable: false),
                    PresentacionFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProcesoFecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OSDestino = table.Column<int>(type: "int", nullable: false),
                    GrupoFamiliar = table.Column<int>(type: "int", nullable: false),
                    NoGrupoFamiliar = table.Column<int>(type: "int", nullable: false),
                    Modalidad = table.Column<int>(type: "int", nullable: false),
                    Zona = table.Column<int>(type: "int", nullable: false),
                    Actividad = table.Column<double>(type: "float", nullable: false),
                    Reduccion = table.Column<double>(type: "float", nullable: false),
                    RemuneracionImponible = table.Column<double>(type: "float", nullable: false),
                    CUILCondicion = table.Column<int>(type: "int", nullable: false),
                    CUILSituacion = table.Column<int>(type: "int", nullable: false),
                    SiniestroCod = table.Column<int>(type: "int", nullable: false),
                    SAC = table.Column<double>(type: "float", nullable: false),
                    HsExtrasImporte = table.Column<double>(type: "float", nullable: false),
                    HsExtrasCantidad = table.Column<int>(type: "int", nullable: false),
                    ZonaDesfavorable = table.Column<double>(type: "float", nullable: false),
                    Vacaciones = table.Column<double>(type: "float", nullable: false),
                    Ajuste = table.Column<double>(type: "float", nullable: false),
                    DiasTrabajados = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    VersionRelease = table.Column<int>(type: "int", nullable: false),
                    Renatea = table.Column<double>(type: "float", nullable: false),
                    CondicionRural = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Archivo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LiquidacionId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_DDJJUatre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadosCiviles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_EstadosCiviles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadosSolicitudes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_EstadosSolicitudes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nacionalidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Nacionalidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provincias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdProvinciaAFIP = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Provincias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Puestos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    table.PrimaryKey("PK_Puestos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seccionales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Domicilio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RefDelegacionId = table.Column<int>(type: "int", nullable: false),
                    RefLocalidadesId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Seccionales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sexos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    table.PrimaryKey("PK_Sexos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposDocumentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_TiposDocumentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefLocalidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodPostal = table.Column<int>(type: "int", nullable: false),
                    LitProvincia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinciaId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_RefLocalidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefLocalidades_Provincias_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SeccionalAutoridades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeccionalId = table.Column<int>(type: "int", nullable: false),
                    AfiliadoId = table.Column<int>(type: "int", nullable: false),
                    RefCargosId = table.Column<int>(type: "int", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaVigenciaDesde = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaVigenciaHasta = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_SeccionalAutoridades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeccionalAutoridades_Seccionales_SeccionalId",
                        column: x => x.SeccionalId,
                        principalTable: "Seccionales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SeccionalContactos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeccionalId = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    Detalle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                    table.PrimaryKey("PK_SeccionalContactos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeccionalContactos_Seccionales_SeccionalId",
                        column: x => x.SeccionalId,
                        principalTable: "Seccionales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Afiliados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CUIL = table.Column<long>(type: "bigint", nullable: false),
                    NroAfiliado = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PuestoId = table.Column<int>(type: "int", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEgreso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NacionalidadId = table.Column<int>(type: "int", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    SeccionalId = table.Column<int>(type: "int", nullable: false),
                    SexoId = table.Column<int>(type: "int", nullable: false),
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: false),
                    Documento = table.Column<long>(type: "bigint", nullable: false),
                    ActividadId = table.Column<int>(type: "int", nullable: false),
                    EstadoSolicitudId = table.Column<int>(type: "int", nullable: false),
                    EstadoSolicitudObservaciones = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    EstadoCivilId = table.Column<int>(type: "int", nullable: false),
                    RefLocalidadId = table.Column<int>(type: "int", nullable: false),
                    Domicilio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AFIPCUIL = table.Column<long>(type: "bigint", nullable: true),
                    AFIPFechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AFIPNombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AFIPApellido = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AFIPRazonSocial = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AFIPTipoDocumento = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AFIPNumeroDocumento = table.Column<long>(type: "bigint", nullable: true),
                    AFIPTipoPersona = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AFIPTipoClave = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AFIPEstadoClave = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AFIPClaveInactivaAsociada = table.Column<long>(type: "bigint", nullable: true),
                    AFIPFechaFallecimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AFIPFormaJuridica = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AFIPActividadPrincipal = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AFIPIdActividadPrincipal = table.Column<int>(type: "int", nullable: true),
                    AFIPPeriodoActividadPrincipal = table.Column<int>(type: "int", nullable: true),
                    AFIPFechaContratoSocial = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AFIPMesCierre = table.Column<int>(type: "int", nullable: true),
                    AFIPDomicilioDireccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AFIPDomicilioCalle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AFIPDomicilioNumero = table.Column<int>(type: "int", nullable: true),
                    AFIPDomicilioPiso = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AFIPDomicilioDepto = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AFIPDomicilioSector = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AFIPDomicilioTorre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AFIPDomicilioManzana = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AFIPDomicilioLocalidad = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AFIPDomicilioProvincia = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AFIPDomicilioIdProvincia = table.Column<int>(type: "int", nullable: true),
                    AFIPDomicilioCodigoPostal = table.Column<int>(type: "int", nullable: true),
                    AFIPDomicilioTipo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AFIPDomicilioEstado = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AFIPDomicilioDatoAdicional = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AFIPDomicilioTipoDatoAdicional = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
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
                    table.PrimaryKey("PK_Afiliados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Afiliados_Actividades_ActividadId",
                        column: x => x.ActividadId,
                        principalTable: "Actividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Afiliados_EstadosCiviles_EstadoCivilId",
                        column: x => x.EstadoCivilId,
                        principalTable: "EstadosCiviles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Afiliados_EstadosSolicitudes_EstadoSolicitudId",
                        column: x => x.EstadoSolicitudId,
                        principalTable: "EstadosSolicitudes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Afiliados_Nacionalidades_NacionalidadId",
                        column: x => x.NacionalidadId,
                        principalTable: "Nacionalidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Afiliados_Puestos_PuestoId",
                        column: x => x.PuestoId,
                        principalTable: "Puestos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Afiliados_RefLocalidades_RefLocalidadId",
                        column: x => x.RefLocalidadId,
                        principalTable: "RefLocalidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Afiliados_Seccionales_SeccionalId",
                        column: x => x.SeccionalId,
                        principalTable: "Seccionales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Afiliados_Sexos_SexoId",
                        column: x => x.SexoId,
                        principalTable: "Sexos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Afiliados_TiposDocumentos_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalTable: "TiposDocumentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SeccionalesLocalidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefLocalidadId = table.Column<int>(type: "int", nullable: false),
                    SeccionalId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_SeccionalesLocalidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeccionalesLocalidades_RefLocalidades_RefLocalidadId",
                        column: x => x.RefLocalidadId,
                        principalTable: "RefLocalidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SeccionalesLocalidades_Seccionales_SeccionalId",
                        column: x => x.SeccionalId,
                        principalTable: "Seccionales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Afiliados_ActividadId",
                table: "Afiliados",
                column: "ActividadId");

            migrationBuilder.CreateIndex(
                name: "IX_Afiliados_CUIL",
                table: "Afiliados",
                column: "CUIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Afiliados_EstadoCivilId",
                table: "Afiliados",
                column: "EstadoCivilId");

            migrationBuilder.CreateIndex(
                name: "IX_Afiliados_EstadoSolicitudId",
                table: "Afiliados",
                column: "EstadoSolicitudId");

            migrationBuilder.CreateIndex(
                name: "IX_Afiliados_NacionalidadId",
                table: "Afiliados",
                column: "NacionalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Afiliados_PuestoId",
                table: "Afiliados",
                column: "PuestoId");

            migrationBuilder.CreateIndex(
                name: "IX_Afiliados_RefLocalidadId",
                table: "Afiliados",
                column: "RefLocalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Afiliados_SeccionalId",
                table: "Afiliados",
                column: "SeccionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Afiliados_SexoId",
                table: "Afiliados",
                column: "SexoId");

            migrationBuilder.CreateIndex(
                name: "IX_Afiliados_TipoDocumentoId",
                table: "Afiliados",
                column: "TipoDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_DDJJUatre_CUIL_Periodo",
                table: "DDJJUatre",
                columns: new[] { "CUIL", "Periodo" });

            migrationBuilder.CreateIndex(
                name: "IX_DDJJUatre_CUIT_Periodo",
                table: "DDJJUatre",
                columns: new[] { "CUIT", "Periodo" });

            migrationBuilder.CreateIndex(
                name: "IX_RefLocalidades_ProvinciaId",
                table: "RefLocalidades",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_SeccionalAutoridades_SeccionalId",
                table: "SeccionalAutoridades",
                column: "SeccionalId");

            migrationBuilder.CreateIndex(
                name: "IX_SeccionalContactos_SeccionalId",
                table: "SeccionalContactos",
                column: "SeccionalId");

            migrationBuilder.CreateIndex(
                name: "IX_SeccionalesLocalidades_RefLocalidadId",
                table: "SeccionalesLocalidades",
                column: "RefLocalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_SeccionalesLocalidades_SeccionalId",
                table: "SeccionalesLocalidades",
                column: "SeccionalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Afiliados");

            migrationBuilder.DropTable(
                name: "DDJJUatre");

            migrationBuilder.DropTable(
                name: "SeccionalAutoridades");

            migrationBuilder.DropTable(
                name: "SeccionalContactos");

            migrationBuilder.DropTable(
                name: "SeccionalesLocalidades");

            migrationBuilder.DropTable(
                name: "Actividades");

            migrationBuilder.DropTable(
                name: "EstadosCiviles");

            migrationBuilder.DropTable(
                name: "EstadosSolicitudes");

            migrationBuilder.DropTable(
                name: "Nacionalidades");

            migrationBuilder.DropTable(
                name: "Puestos");

            migrationBuilder.DropTable(
                name: "Sexos");

            migrationBuilder.DropTable(
                name: "TiposDocumentos");

            migrationBuilder.DropTable(
                name: "RefLocalidades");

            migrationBuilder.DropTable(
                name: "Seccionales");

            migrationBuilder.DropTable(
                name: "Provincias");
        }
    }
}
