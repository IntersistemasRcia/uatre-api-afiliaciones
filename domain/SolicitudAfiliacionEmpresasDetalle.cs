using CleanArchitecture.Domain.Commom;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain
{
    public class SolicitudAfiliacionEmpresasDetalle : EntidadAuditable
    {
        public int SolicitudAfiliacionEmpresasId { get; set; }
        public SolicitudAfiliacionEmpresas? SolicitudAfiliacionEmpresas { get; set; }
        public int? Periodo { get; set; }
        public Int64? Total_Trabajadores { get; set; }
        public int? Total_Trab_Rurales { get; set; }
        public int? Total_Trab_NoRurales { get; set; }
        public int? Total_Trab_Rurales_Afiliados { get; set; }
        public int? Total_Trab_Rurales_NoAfiliados { get; set; }
        public int? Total_Trab_NoRurales_Afiliados { get; set; }
        public int? Total_Trab_NoRurales_NoAfiliados { get; set; }
    }
}
