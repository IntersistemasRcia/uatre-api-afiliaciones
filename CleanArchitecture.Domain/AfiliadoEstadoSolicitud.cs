using CleanArchitecture.Domain.Commom;

namespace CleanArchitecture.Domain
{
    public class AfiliadoEstadoSolicitud : BaseDomainModel
    {
        public AfiliadoEstadoSolicitud()
        {
            
        }
        public AfiliadoEstadoSolicitud(int afiliadoId, int estadoSolicitudAnt)
        {
            this.AfiliadoId = afiliadoId;
            this.EstadoSolicitudId = estadoSolicitudAnt;
        }
        public int AfiliadoId { get; set; }
        public Afiliado? Afiliado { get; set; }
        public int EstadoSolicitudId { get; set; }
        public EstadoSolicitud? EstadoSolicitud { get; set; }
    }
}
