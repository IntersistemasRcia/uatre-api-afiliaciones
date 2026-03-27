using CleanArchitecture.Domain.Commom;

namespace CleanArchitecture.Application.Features.EstadoCivil.Queries
{
    public class EstadoCivilVm : EntidadAuditable
    {
        public string? Descripcion { get; set; }
    }
}
