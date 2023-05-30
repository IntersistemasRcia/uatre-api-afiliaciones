using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.AfiliadoEstadoSolicitud.Queries
{
    public class AfiliadoEstadoSolicitudVm
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? EstadoSolicitudDescripcion { get; set; }
    }
}
