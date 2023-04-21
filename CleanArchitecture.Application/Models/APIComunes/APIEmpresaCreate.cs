namespace CleanArchitecture.Application.Models.APIComunes
{
    public class APIEmpresaCreate
    {
        public double CUIT { get; set; }
        public string? RazonSocial { get; set; }
        public string? ClaveTipo { get; set; }
        public string? ClaveEstado { get; set; }
        public double? ClaveInactivaAsociada { get; set; }
        public string? ActividadPrincipalDescripcion { get; set; }
        public int? ActividadPrincipalId { get; set; }
        public int? ActividadPrincipalPeriodo { get; set; }
        public DateTime? ContratoSocialFecha { get; set; }
        public byte? CierreMes { get; set; }
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? DomicilioCalle { get; set; }
        public int? DomicilioNumero { get; set; }
        public string? DomicilioPiso { get; set; }
        public string? DomicilioDpto { get; set; }
        public string? DomicilioSector { get; set; }
        public string? DomicilioTorre { get; set; }
        public string? DomicilioManzana { get; set; }
        public int? DomicilioProvinciasId { get; set; }
        public int? DomicilioLocalidadesId { get; set; }
        public int? DomicilioCodigoPostal { get; set; }
        public string? DomicilioCPA { get; set; }
        public string? DomicilioTipo { get; set; }
        public string? DomicilioEstado { get; set; }
        public string? DomicilioDatoAdicional { get; set; }
        public string? DomicilioDatoAdicionalTipo { get; set; }
        public int? CIIU1 { get; set; }
        public int? CIIU2 { get; set; }
        public int? CIIU3 { get; set; }
    }
}
