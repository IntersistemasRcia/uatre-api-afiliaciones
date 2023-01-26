using CleanArchitecture.Domain.Commom;

namespace CleanArchitecture.Domain
{
    public class Seccional : BaseDomainModel
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        //public int LocalidadId { get; set; }
        //public Localidad Localidad { get; set; }
    }
}
