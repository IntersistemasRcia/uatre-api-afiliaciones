using CleanArchitecture.Domain.Commom;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain;

public class AfiliadoFormularioAfiliacion : EntidadAuditable
{
    public DateTime Fecha { get; set; }
    public long CUIL { get; set; }

    [StringLength(100)]
    public string? Apellido { get; set; }

    [StringLength(100)]
    public string? Nombre { get; set; }

    [StringLength(200)]
    public string? Domicilio { get; set; }

    [StringLength(100)]
    public string? Telefono { get; set; }

    [StringLength(100)]
    public string? Celular { get; set; }

    [StringLength(200)]
    public string? Email { get; set; }

    public int SexoId { get; set; }

    public int TipoDocumentoId { get; set; }

    public long Documento { get; set; }

    public int EstadoCivilId { get; set; }

    [StringLength(100)]
    public string? EstadoCivil { get; set; }

    public int SeccionalId { get; set; }

    [StringLength(100)]
    public string? Seccional { get; set; }

    public int OficioId { get; set; }

    [StringLength(100)]
    public string? Oficio { get; set; }

    public int ActividadIdAfiliado { get; set; }

    [StringLength(200)]
    public string? ActividadAfiliado { get; set; }

    public int NacionalidadId { get; set; }

    [StringLength(100)]
    public string? Nacionalidad { get; set; }

    public int RefLocalidadIdAfiliado { get; set; }

    [StringLength(100)]
    public string? NombreLocalidadAfiliado { get; set; }

    public int ProvinciaId { get; set; }

    public long CUITEmpresa { get; set; }

    [StringLength(200)]
    public string? RazonSocial { get; set; }

    [StringLength(200)]
    public string? DomicilioEmpresa { get; set; }

    public int RefLocalidadIdEmpresa { get; set; }

    [StringLength(200)]
    public string? NombreLocalidadEmpresa { get; set; }

    public int ProvinciaidEmpresa { get; set; }

    public int ActividadIdEmpresa { get; set; }

    [StringLength(200)]
    public string? ActividadEmpresa { get; set; }

    [StringLength(100)]
    public string? TelefonoEmpresa { get; set; }

    [StringLength(100)]
    public string? CelularEmpresa { get; set; }

    [StringLength(200)]
    public string? EmailEmpresa { get; set; }

    public DateTime FechaNacimiento { get; set; }

    public DateTime FechaIncorporacion { get; set; }

    public int AfiliadoIdAsignado { get; set; }

    [StringLength(1000)]
    public string? Observaciones { get; set; }
}
