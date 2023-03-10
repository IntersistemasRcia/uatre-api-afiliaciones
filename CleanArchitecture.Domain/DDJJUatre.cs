using CleanArchitecture.Domain.Commom;

namespace CleanArchitecture.Domain
{
    public class DDJJUatre : BaseDomainModel
    {
        public double CUIT { get; set; }
        public double CUIL { get; set; }
        public int Periodo { get; set; }
        public double ObligacionNro { get; set; }
        public int ObligacionSecuencia { get; set; }
        public int Banco { get; set; }
        public int Rectificativa { get; set; }
        public DateTime PresentacionFecha { get; set; }
        public DateTime ProcesoFecha { get; set; }
        public int OSDestino { get; set; }
        public int GrupoFamiliar { get; set; }
        public int NoGrupoFamiliar { get; set; }
        public int Modalidad { get; set; }
        public int Zona { get; set; }
        public double Actividad { get; set; }
        public double Reduccion { get; set; }
        public double RemuneracionImponible { get; set; }
        public int CUILCondicion { get; set; }
        public int CUILSituacion { get; set; }
        public int SiniestroCod { get; set; }
        public double SAC { get; set; }
        public double HsExtrasImporte { get; set; }
        public int HsExtrasCantidad { get; set; }
        public double ZonaDesfavorable { get; set; }
        public double Vacaciones { get; set; }
        public double Ajuste { get; set; }
        public int DiasTrabajados { get; set; }
        public int Version { get; set; }
        public int VersionRelease { get; set; }
        public double Renatea { get; set; }
        //public int LiquidacionId { get; set; }
        public Empresas? Empresa { get; set; }
    }
}
