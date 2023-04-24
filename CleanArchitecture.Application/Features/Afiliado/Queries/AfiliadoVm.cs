using CleanArchitecture.Domain;

namespace CleanArchitecture.Application.Features.Afiliado.Queries
{
    public class AfiliadoVm
    {
        public int Id { get; set; }
        public long CUIL { get; set; }
        public int Secuencia { get; set; }
        public int NroAfiliado { get; set; }
        public string? Nombre { get; set; }
        public int PuestoId { get; set; }
        public string? Puesto { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaEgreso { get; set; }
        public int NacionalidadId { get; set; }
        public string? Nacionalidad { get; set; }
        public int EmpresaId { get; set; }
        public double? EmpresaCUIT { get; set; }
        public string? EmpresaDescripcion { get; set; }
        public int ProvinciaId { get; set; }
        public string? Provincia { get; set; }
        public int RefLocalidadId { get; set; }
        public string? Localidad { get; set; }
        public int SeccionalId { get; set; }
        public string? Seccional { get; set; }
        public int SexoId { get; set; }
        public string? Sexo { get; set; }
        public long Documento { get; set; }
        public int ActividadId { get; set; }
        public string? Actividad { get; set; }
        public int EstadoSolicitudId { get; set; }
        public string? EstadoSolicitud { get; set; }        
        public string? EstadoSolicitudObservaciones { get; set; }
        public int TipoDocumentoId { get; set; }
        public string? TipoDocumento { get; set; }
        public int EstadoCivilId { get; set; }
        public string? EstadoCivil { get; set; }
        public string? Domicilio { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public long? AFIPCUIL { get; set; }
        public DateTime? AFIPFechaNacimiento { get; set; }
        public string? AFIPNombre { get; set; }
        public string? AFIPApellido { get; set; }
        public string? AFIPRazonSocial { get; set; }
        public string? AFIPTipoDocumento { get; set; }
        public Int64? AFIPNumeroDocumento { get; set; }
        public string? AFIPTipoPersona { get; set; }
        public string? AFIPTipoClave { get; set; }
        public string? AFIPEstadoClave { get; set; }
        public long? AFIPClaveInactivaAsociada { get; set; }
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
        public int SeccionalAutoridadId { get; set; }
    }
}
