using CleanArchitecture.Domain.Commom;

namespace CleanArchitecture.Application.Features.SeccionalContacto.Queries
{
    public class SeccionalContactoResponse : EntidadAuditable
    {
        public int SeccionalId { get; set; }
        public string? SeccionalDescripcion { get; set; }
        public string? Tipo { get; set; }
        public string? Detalle { get; set; }
    }
}
