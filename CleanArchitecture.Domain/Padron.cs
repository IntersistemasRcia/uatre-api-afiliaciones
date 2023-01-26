using CleanArchitecture.Domain.Commom;

namespace CleanArchitecture.Domain
{
    public class Padron : BaseDomainModel
    {
        public Int64 CUIL { get; set; }
        public int Secuencia { get; set; }
        public int Afiliado { get; set; }
        public string Nombre { get; set; }
        public int PuestoId { get; set; }
        public Puesto Puesto { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaEgreso { get; set; }
        public string Nacionalidad { get; set; }
        public string NombreAnexo { get; set; }
        public Int64 CUIT { get; set; }
        public int ProvinciaId { get; set; }
        public Provincia Provincia { get; set; }
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
}
