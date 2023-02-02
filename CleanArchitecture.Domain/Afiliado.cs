using CleanArchitecture.Domain.Commom;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain
{
    public class Afiliado : BaseDomainModel
    {
        public Int64 CUIL { get; set; }
        public int Secuencia { get; set; }
        public int NroAfiliado { get; set; }
        [StringLength(100)]
        public string Nombre { get; set; }
        public int PuestoId { get; set; }
        public Puesto Puesto { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaEgreso { get; set; }        
        public int NacionalidadId { get; set; }
        public Nacionalidad Nacionalidad { get; set; }
        [StringLength(100)]
        public string NombreAnexo { get; set; }
        public Int64 CUIT { get; set; }        
        public int SeccionalId { get; set; }
        public Seccional Seccional { get; set; }
        public int SexoId { get; set; }
        public Sexo Sexo { get; set; }
        public Int64 DNI { get; set; }
        public int ActividadId { get; set; }
        public Actividad Actividad { get; set; }
        public int EstadoSolicitudId { get; set; }
        public EstadoSolicitud EstadoSolicitud { get; set; }
        public Int64? AFIPCUIL { get; set; }
        public DateTime? AFIPFechaNacimiento { get; set; }
        [StringLength(50)]
        public string? AFIPNombre { get; set; }
        [StringLength(50)]
        public string? AFIPApellido { get; set; }
        [StringLength(200)]
        public string? AFIPRazonSocial { get; set; }
        [StringLength(50)]
        public string? AFIPTipoDocumento { get; set; }
        public int? AFIPNumeroDocumento { get; set; }
        [StringLength(50)]
        public string? AFIPTipoPersona { get; set; }
        [StringLength(50)]
        public string? AFIPTipoClave { get; set; }
        [StringLength(50)]
        public string? AFIPEstadoClave { get; set; }
        public Int64? AFIPClaveInactivaAsociada { get; set; }
        public DateTime? AFIPFechaFallecimiento { get; set; }
        [StringLength(50)]
        public string? AFIPFormaJuridica { get; set; }
        [StringLength(200)]
        public string? AFIPActividadPrincipal { get; set; }
        public int? AFIPIdActividadPrincipal { get; set; }
        public int? AFIPPeriodoActividadPrincipal { get; set; }
        public DateTime? AFIPFechaContratoSocial { get; set; }
        public int? AFIPMesCierre { get; set; }
        [StringLength(200)]
        public string? AFIPDomicilioDireccion { get; set; }
        [StringLength(50)]
        public string? AFIPDomicilioCalle { get; set; }
        public int? AFIPDomicilioNumero { get; set; }
        [StringLength(50)]
        public string? AFIPDomicilioPiso { get; set; }
        [StringLength(50)]
        public string? AFIPDomicilioDepto { get; set; }
        [StringLength(50)]
        public string? AFIPDomicilioSector { get; set; }
        [StringLength(50)]
        public string? AFIPDomicilioTorre { get; set; }
        [StringLength(50)]
        public string? AFIPDomicilioManzana { get; set; }
        [StringLength(50)]
        public string? AFIPDomicilioLocalidad { get; set; }
        [StringLength(50)]
        public string? AFIPDomicilioProvincia { get; set; }
        public int? AFIPDomicilioIdProvincia { get; set; }
        public int? AFIPDomicilioCodigoPostal { get; set; }
        [StringLength(50)]
        public string? AFIPDomicilioTipo { get; set; }
        [StringLength(50)]
        public string? AFIPDomicilioEstado { get; set; }
        [StringLength(50)]
        public string? AFIPDomicilioDatoAdicional { get; set; }
        [StringLength(50)]
        public string? AFIPDomicilioTipoDatoAdicional { get; set; }
    }
}
