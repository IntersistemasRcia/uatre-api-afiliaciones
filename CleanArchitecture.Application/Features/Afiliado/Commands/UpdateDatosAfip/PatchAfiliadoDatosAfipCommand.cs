using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace CleanArchitecture.Application.Features.Afiliado.Commands.UpdateDatosAfip;

public class PatchAfiliadoDatosAfipCommand : IRequest<int>
{
    public PatchAfiliadoDatosAfipCommand(int id, PatchAfiliadoDatosAfipDto dto)
    {
        Id = id;
        AFIPFechaNacimiento = dto.AFIPFechaNacimiento;
        AFIPNombre = dto.AFIPNombre;
        AFIPApellido = dto.AFIPApellido;
        AFIPRazonSocial = dto.AFIPRazonSocial;
        AFIPTipoDocumento = dto.AFIPTipoDocumento;
        AFIPNumeroDocumento = dto.AFIPNumeroDocumento;
        AFIPTipoPersona = dto.AFIPTipoPersona;
        AFIPTipoClave = dto.AFIPTipoClave;
        AFIPEstadoClave = dto.AFIPEstadoClave;
        AFIPClaveInactivaAsociada = dto.AFIPClaveInactivaAsociada;
        AFIPFechaFallecimiento = dto.AFIPFechaFallecimiento;
        AFIPFormaJuridica = dto.AFIPFormaJuridica;
        AFIPActividadPrincipal = dto.AFIPActividadPrincipal;
        AFIPIdActividadPrincipal = dto.AFIPIdActividadPrincipal;
        AFIPPeriodoActividadPrincipal = dto.AFIPPeriodoActividadPrincipal;
        AFIPFechaContratoSocial = dto.AFIPFechaContratoSocial;
        AFIPMesCierre = dto.AFIPMesCierre;
        AFIPDomicilioDireccion = dto.AFIPDomicilioDireccion;
        AFIPDomicilioCalle = dto.AFIPDomicilioCalle;
        AFIPDomicilioNumero = dto.AFIPDomicilioNumero;
        AFIPDomicilioPiso = dto.AFIPDomicilioPiso;
        AFIPDomicilioDepto = dto.AFIPDomicilioDepto;
        AFIPDomicilioSector = dto.AFIPDomicilioSector;
        AFIPDomicilioTorre = dto.AFIPDomicilioTorre;
        AFIPDomicilioManzana = dto.AFIPDomicilioManzana;
        AFIPDomicilioLocalidad = dto.AFIPDomicilioLocalidad;
        AFIPDomicilioProvincia = dto.AFIPDomicilioProvincia;
        AFIPDomicilioIdProvincia = dto.AFIPDomicilioIdProvincia;
        AFIPDomicilioCodigoPostal = dto.AFIPDomicilioCodigoPostal;
        AFIPDomicilioTipo = dto.AFIPDomicilioTipo;
        AFIPDomicilioEstado = dto.AFIPDomicilioEstado;
        AFIPDomicilioDatoAdicional = dto.AFIPDomicilioDatoAdicional;
        AFIPDomicilioTipoDatoAdicional = dto.AFIPDomicilioTipoDatoAdicional;
    }

    public int Id { get; set; }
    public DateTime? AFIPFechaNacimiento { get; set; }
    public string? AFIPNombre { get; set; }
    public string? AFIPApellido { get; set; }
    public string? AFIPRazonSocial { get; set; }
    public string? AFIPTipoDocumento { get; set; }
    public int? AFIPNumeroDocumento { get; set; }
    public string? AFIPTipoPersona { get; set; }
    public string? AFIPTipoClave { get; set; }
    public string? AFIPEstadoClave { get; set; }
    public Int64? AFIPClaveInactivaAsociada { get; set; }
    public DateTime? AFIPFechaFallecimiento { get; set; }
    public string? AFIPFormaJuridica { get; set; }
    public string? AFIPActividadPrincipal { get; set; }
    public int? AFIPIdActividadPrincipal { get; set; }
    public int? AFIPPeriodoActividadPrincipal { get; set; }
    public DateTime? AFIPFechaContratoSocial { get; set; }
    public int? AFIPMesCierre { get; set; }
    public string? AFIPDomicilioDireccion { get; set; }
    public string? AFIPDomicilioCalle { get; set; }
    public int? AFIPDomicilioNumero { get; set; }
    public string? AFIPDomicilioPiso { get; set; }
    public string? AFIPDomicilioDepto { get; set; }
    public string? AFIPDomicilioSector { get; set; }
    public string? AFIPDomicilioTorre { get; set; }
    public string? AFIPDomicilioManzana { get; set; }
    public string? AFIPDomicilioLocalidad { get; set; }
    public string? AFIPDomicilioProvincia { get; set; }
    public int? AFIPDomicilioIdProvincia { get; set; }
    public int? AFIPDomicilioCodigoPostal { get; set; }
    public string? AFIPDomicilioTipo { get; set; }
    public string? AFIPDomicilioEstado { get; set; }
    public string? AFIPDomicilioDatoAdicional { get; set; }
    public string? AFIPDomicilioTipoDatoAdicional { get; set; }
}
