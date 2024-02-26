using CleanArchitecture.Domain.Commom;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain
{
    public class Afiliado : EntidadAuditable
    {
        [Required]
        public Int64 CUIL { get; set; }
        public Int64 CUILValidado { get; set; }
        public int NroAfiliado { get; set; }
        [StringLength(255)]
        public string? Nombre { get; set; }
        public int PuestoId { get; set; }
        public Puesto? Puesto { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaEgreso { get; set; }        
        public int NacionalidadId { get; set; }
        public Nacionalidad? Nacionalidad { get; set; }
        [StringLength(255)]
        public int EmpresaId { get; set; }        
        public int SeccionalId { get; set; }
        public Seccional? Seccional { get; set; }
        public int SexoId { get; set; }
        public Sexo? Sexo { get; set; }
        public int TipoDocumentoId { get; set; }
        public TipoDocumento? TipoDocumento { get; set; }
        public Int64 Documento { get; set; }
        public int ActividadId { get; set; }
        public Actividad? Actividad { get; set; }
        public int EstadoSolicitudId { get; set; }
        public EstadoSolicitud? EstadoSolicitud { get; set; }
        [StringLength(1000)]
        public string? EstadoSolicitudObservaciones { get; set; }
        public int EstadoCivilId { get; set; }
        public EstadoCivil? EstadoCivil { get; set; }
        public int RefLocalidadId { get; set; }
        public RefLocalidad? RefLocalidad { get; set; }
        //[StringLength(1000)]
        //public string? ResolucionSolicitudObservaciones { get; set; }
        [StringLength(255)]
        public string? Domicilio { get; set; }
        [StringLength(255)]
        public string? Telefono { get; set; }
        [StringLength(255)]
        public string? Celular { get; set; }
        [StringLength(255)]
        public string? Correo { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public Int64? AFIPCUIL { get; set; }
        public DateTime? AFIPFechaNacimiento { get; set; }
        [StringLength(255)]
        public string? AFIPNombre { get; set; }
        [StringLength(255)]
        public string? AFIPApellido { get; set; }
        [StringLength(255)]
        public string? AFIPRazonSocial { get; set; }
        [StringLength(255)]
        public string? AFIPTipoDocumento { get; set; }
        public Int64? AFIPNumeroDocumento { get; set; }
        [StringLength(255)]
        public string? AFIPTipoPersona { get; set; }
        [StringLength(255)]
        public string? AFIPTipoClave { get; set; }
        [StringLength(255)]
        public string? AFIPEstadoClave { get; set; }
        public Int64? AFIPClaveInactivaAsociada { get; set; }
        public DateTime? AFIPFechaFallecimiento { get; set; }
        [StringLength(255)]
        public string? AFIPFormaJuridica { get; set; }
        [StringLength(255)]
        public string? AFIPActividadPrincipal { get; set; }
        public int? AFIPIdActividadPrincipal { get; set; }
        public int? AFIPPeriodoActividadPrincipal { get; set; }
        public DateTime? AFIPFechaContratoSocial { get; set; }
        public int? AFIPMesCierre { get; set; }
        [StringLength(255)]
        public string? AFIPDomicilioDireccion { get; set; }
        [StringLength(255)]
        public string? AFIPDomicilioCalle { get; set; }
        public int? AFIPDomicilioNumero { get; set; }
        [StringLength(255)]
        public string? AFIPDomicilioPiso { get; set; }
        [StringLength(255)]
        public string? AFIPDomicilioDepto { get; set; }
        [StringLength(255)]
        public string? AFIPDomicilioSector { get; set; }
        [StringLength(255)]
        public string? AFIPDomicilioTorre { get; set; }
        [StringLength(50)]
        public string? AFIPDomicilioManzana { get; set; }
        [StringLength(255)]
        public string? AFIPDomicilioLocalidad { get; set; }
        [StringLength(255)]
        public string? AFIPDomicilioProvincia { get; set; }
        public int? AFIPDomicilioIdProvincia { get; set; }
        public int? AFIPDomicilioCodigoPostal { get; set; }
        [StringLength(255)]
        public string? AFIPDomicilioTipo { get; set; }
        [StringLength(255)]
        public string? AFIPDomicilioEstado { get; set; }
        [StringLength(255)]
        public string? AFIPDomicilioDatoAdicional { get; set; }
        [StringLength(255)]
        public string? AFIPDomicilioTipoDatoAdicional { get; set; }
        public int SeccionalIdSolicitudAfiliacion { get; set; }

        [NotMapped]
        public int SeccionalAutoridadId { get; set; }
        [NotMapped]
        public string? EmpresaDescripcion { get; set; }
        [NotMapped]
        public double? EmpresaCUIT { get; set; }
        public int RefMotivoBajaId { get; set; }
        [NotMapped]
        public string? RefMotivoBajaDescripcion { get; set; }
    }
}
