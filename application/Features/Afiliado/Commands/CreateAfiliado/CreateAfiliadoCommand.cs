using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Models.APIComunes;
using MediatR;

namespace CleanArchitecture.Application.Features.Afiliado.Commands.CreateAfiliado
{
    public class CreateAfiliadoCommand : IRequest<int>
    {
        public Int64 CUIL { get; set; }
        public Int64 CUILValidado { get; set; }
        public int NroAfiliado { get; set; }
        public string? Nombre { get; set; }
        public int PuestoId { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaEgreso { get; set; }
        public int NacionalidadId { get; set; }
        public double EmpresaCuit { get; set; }
        public int SeccionalId { get; set; }
        public int SexoId { get; set; }
        public int TipoDocumentoId { get; set; }
        public Int64 Documento { get; set; }
        public int ActividadId { get; set; }
        public int EstadoSolicitudId { get; set; }
        public string? EstadoSolicitudObservaciones { get; set; }
        public int EstadoCivilId { get; set; }
        public int RefLocalidadId { get; set; }
        public string? Domicilio { get; set; }
        //public string? Telefono { get; set; }
        public string? TelefonoPais { get; set; }
        public string? TelefonoArea { get; set; }
        public string? TelefonoNumero { get; set; }
        public string? Correo { get; set; }
        public string? Celular { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public Int64 AFIPCUIL { get; set; }
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
        public int SeccionalIdSolicitudAfiliacion { get; set; }
        public APIEmpresaCreate? Empresa { get; set; }
        public ICollection<DocumentacionEntidad>? Documentacion { get; set; }
    }
}
