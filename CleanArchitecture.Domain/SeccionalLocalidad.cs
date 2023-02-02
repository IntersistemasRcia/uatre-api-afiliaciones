using CleanArchitecture.Domain.Commom;

namespace CleanArchitecture.Domain
{
    public class SeccionalLocalidad : BaseDomainModel
    {
        public int LocalidadId { get; set; }
        public Localidad Localidad { get; set; }
        public int SeccionalId { get; set; }
        public Seccional Seccional { get; set; }
    }
}
