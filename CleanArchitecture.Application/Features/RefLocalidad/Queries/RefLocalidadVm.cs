namespace CleanArchitecture.Application.Features.RefLocalidad.Queries
{
    public class RefLocalidadVm
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int CodPostal { get; set; }
        public string? Provincia { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
