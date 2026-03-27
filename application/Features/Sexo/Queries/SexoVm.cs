using CleanArchitecture.Domain.Commom;

namespace CleanArchitecture.Application.Features.Sexo.Queries
{
    public class SexoVm : EntidadAuditable
    {
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
    }
}
