using CleanArchitecture.Domain.Commom;

namespace CleanArchitecture.Application.Features.TipoDocumento.Queries
{
    public class TipoDocumentoVm : EntidadAuditable
    {       
        public string? Descripcion { get; set; }
    }
}
