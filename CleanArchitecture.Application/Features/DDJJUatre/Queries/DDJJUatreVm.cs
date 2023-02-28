namespace CleanArchitecture.Application.Features.DDJJUatre.Queries
{
    public class DDJJUatreVm
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
        public double RemuneracionImponible { get; set; }
        public string? Empresa { get; set; }
    }
}
