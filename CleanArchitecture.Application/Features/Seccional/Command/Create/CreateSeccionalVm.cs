namespace CleanArchitecture.Application.Features.Seccional.Command.Create
{
    public class CreateSeccionalVm
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public string? Domicilio { get; set; }
        public string? Estado { get; set; }
        public string? Observaciones { get; set; }
    }
}
