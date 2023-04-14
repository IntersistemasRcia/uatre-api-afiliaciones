using CleanArchitecture.Domain.Commom;

namespace CleanArchitecture.Domain
{
    public class SeccionalLocalidad : BaseDomainModel
    {
        public SeccionalLocalidad()
        {
            //RefLocalidad = new RefLocalidad();
            Seccional = new Seccional();
        }
        public int RefLocalidadId { get; set; }
        public RefLocalidad RefLocalidad { get; set; }
        public int SeccionalId { get; set; }
        public Seccional Seccional { get; set; }
    }
}
