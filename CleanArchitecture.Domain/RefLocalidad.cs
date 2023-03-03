using CleanArchitecture.Domain.Commom;

namespace CleanArchitecture.Domain
{
    public class RefLocalidad : BaseDomainModel
    {
        public int Codigo { get; set; }
        public string? Nombre { get; set; }
        public int CodPostal { get; set; }
        public string? LitProvincia { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Tipo { get; set; }
        public int ProvinciaId { get; set; }
        public Provincia? Provincia { get; set; }
        public ICollection<SeccionalLocalidad>? SeccionalLocalidad { get; set; }
    }
}
