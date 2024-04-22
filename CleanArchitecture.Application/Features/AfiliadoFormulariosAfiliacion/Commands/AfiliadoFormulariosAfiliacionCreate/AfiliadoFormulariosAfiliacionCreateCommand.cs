using MediatR;

namespace CleanArchitecture.Application.Features.AfiliadoFormulariosAfiliacion.Commands.AfiliadoFormulariosAfiliacionCreate;

public class AfiliadoFormulariosAfiliacionCreateCommand : IRequest<int>
{
    public required DateTime Fecha { get; set; }

    public required long CUIL { get; set; }

    public required string? Apellido { get; set; }

    public required string? Nombre { get; set; }

    public required string? Domicilio { get; set; }

    public required string? Telefono { get; set; }

    public required string? Celular { get; set; }

    public required string? Email { get; set; }

    public required int SexoId { get; set; }

    public required int TipoDocumentoId { get; set; }

    public required long Documento { get; set; }

    public required int EstadoCivilId { get; set; }

    public required string? EstadoCivil { get; set; }

    public required int SeccionalId { get; set; }

    public required string? Seccional { get; set; }

    public required int OficioId { get; set; }

    public required string? Oficio { get; set; }

    public required int ActividadIdAfiliado { get; set; }

    public required string? ActividadAfiliado { get; set; }

    public required int NacionalidadId { get; set; }

    public required string? Nacionalidad { get; set; }

    public required int RefLocalidadIdAfiliado { get; set; }

    public required string? NombreLocalidadAfiliado { get; set; }

    public required int ProvinciaId { get; set; }

    public required long CUITEmpresa { get; set; }

    public required string? RazonSocial { get; set; }

    public required string? DomicilioEmpresa { get; set; }

    public required int RefLocalidadIdEmpresa { get; set; }

    public required string? NombreLocalidadEmpresa { get; set; }

    public required int ProvinciaidEmpresa { get; set; }

    public required int ActividadIdEmpresa { get; set; }

    public required string? ActividadEmpresa { get; set; }

    public required string? TelefonoEmpresa { get; set; }

    public required string? CelularEmpresa { get; set; }

    public required string? EmailEmpresa { get; set; }

    public required DateTime FechaNacimiento { get; set; }

    public required DateTime FechaIncorporacion { get; set; }

    public required int AfiliadoIdAsignado { get; set; }

    public required string? Observaciones { get; set; }
}
