using MediatR;

namespace CleanArchitecture.Application.Features.RefLocalidad.Command.Update
{
    public class UpdateRefLocalidadCommand : IRequest<int>
    {
        public  int Id { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int CodPostal { get; set; }
        public string LitProvincia { get; set; }
        public string NombreCompleto { get; set; }
        public string Tipo { get; set; }
        public int ProvinciaId { get; set; }
    }
}
