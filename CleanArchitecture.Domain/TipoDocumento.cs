using CleanArchitecture.Domain.Commom;

namespace CleanArchitecture.Domain
{
    public class TipoDocumento : EntidadAuditable
    {
        public string? Descripcion { get; set; }
    }
}
